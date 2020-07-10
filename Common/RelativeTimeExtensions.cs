using System;


namespace erecruta.Common
{
	public static class RelativeTimeExtensions
	{
		public static String RelativeTime(this TimeSpan ts)
		{
			const int second = 1;
			const int minute = 60 * second;
			const int hour = 60 * minute;
			const int day = 24 * hour;
			const int month = 30 * day;
			double delta = Math.Abs(ts.TotalSeconds);
			//melhor se escrever só "Agora há pouco"
			if (delta < 1 * minute) return "Há " + (ts.Seconds == 1 ? "um segundo" : ts.Seconds + " segundos");
			if (delta < 2 * minute) return "Há um minuto";
			if (delta < 45 * minute) return "Há " + ts.Minutes + " minutos";
			if (delta < 90 * minute) return "Há uma hora";
			if (delta < 24 * hour) return "Há " + ts.Hours + " horas";
			if (delta < 48 * hour) return "Ontem";
			if (delta < 30 * day) return "Há " + ts.Days + " dias";
			if (delta < 12 * month)
			{
				var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
				return "Há " + (months <= 1 ? "um mês" : months + " meses");
			}
			else
			{
				var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
				return "Há " + (years <= 1 ? "um ano" : years + " anos");
			}
		}
	}
}
