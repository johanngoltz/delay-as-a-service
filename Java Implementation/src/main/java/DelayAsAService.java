import io.fouad.jtb.core.JTelegramBot;
import io.fouad.jtb.core.TelegramBotConfig.TelegramBotConfigBuilder;

public class DelayAsAService
{

	public static void main(String[] args)
	{
		// TODO Auto-generated method stub
		JTelegramBot delayBot = new JTelegramBot("VrnDelayBot", "214078419:AAEOEmUoGqeROggNS5ztWxiTVFzDmd9V_Vs",
				new DelayBot());
		delayBot.start();
	}

}
