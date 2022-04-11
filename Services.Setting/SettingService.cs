using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Setting
{
    public class SettingService : ISettingService
    {
		const string settingServiceCacheKey = "settingServiceCacheKey";
		private AircashSimulatorContext AircashSimulatorContext;
		private readonly IMemoryCache MemoryCache;

		public string PrivateKeyPath { get { return GetSetting("PrivateKeyPath", String.Empty, throwExceptionIfMissing: true); } }

		public SettingService(AircashSimulatorContext aircashSimulatorContext, IMemoryCache memoryCache)
		{
			AircashSimulatorContext = aircashSimulatorContext;
			MemoryCache = memoryCache;
		}

		T GetSetting<T>(string key, T defaultValue, bool throwExceptionIfMissing = false)
		{
			var dictSettings = GetSettings();
			if (!dictSettings.TryGetValue(key, out string strValue))
			{
				if (throwExceptionIfMissing)
					throw new ArgumentException($"Unable to find setting with key {key}");
				return defaultValue;
			}

			var type = typeof(T);

			if (type == typeof(int))
			{
				if (!int.TryParse(strValue, out int value))
					return defaultValue;
				else
					return (T)Convert.ChangeType(value, type);
			}
			else if (type == typeof(bool))
				return (T)Convert.ChangeType(strValue == "1", type);
			else if (type == typeof(string))
				return (T)Convert.ChangeType(strValue, type);
			else if (type == typeof(Guid))
			{
				if (Guid.TryParse(strValue, out Guid guidValue))
					return (T)Convert.ChangeType(guidValue, type);
				else
					return defaultValue;
			}
			else if (type == typeof(List<string>))
				return (T)Convert.ChangeType(new List<string>(strValue.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)), type);
			else if (type == typeof(HashSet<string>))
				return (T)Convert.ChangeType(new HashSet<string>(strValue.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries)), type);
			else if (type == typeof(double))
			{
				if (!double.TryParse(strValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
					return defaultValue;
				else
					return (T)Convert.ChangeType(value, type);
			}
			else if (type == typeof(decimal))
			{
				if (!decimal.TryParse(strValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
					return defaultValue;
				else
					return (T)Convert.ChangeType(value, type);
			}
			else if (type == typeof(DateTime))
			{
				if (!DateTime.TryParse(strValue, out DateTime dateTime))
					return defaultValue;
				else
					return (T)Convert.ChangeType(dateTime, type);
			}

			else
				throw new Exception($"Unknown type {type}");
		}

		public Dictionary<string, string> GetSettings()
		{
			if (!MemoryCache.TryGetValue(settingServiceCacheKey, out Dictionary<string, string> dictSettings))
			{
				dictSettings = AircashSimulatorContext.Settings.ToDictionary(x => x.Key, x => x.Value);
				MemoryCache.Set(settingServiceCacheKey, dictSettings);
			}

			return dictSettings;
		}

		public async Task RefreshSettings()
		{
			var dictSettings = await AircashSimulatorContext.Settings.ToDictionaryAsync(x => x.Key, x => x.Value);
			MemoryCache.Set(settingServiceCacheKey, dictSettings);
		}
	}
	
}
