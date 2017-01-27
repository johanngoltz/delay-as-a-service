package userCommunication;
import java.io.IOException;

import io.fouad.jtb.core.TelegramBotApi;
import io.fouad.jtb.core.UpdateHandler;
import io.fouad.jtb.core.beans.CallbackQuery;
import io.fouad.jtb.core.beans.ChosenInlineResult;
import io.fouad.jtb.core.beans.InlineQuery;
import io.fouad.jtb.core.beans.Message;
import io.fouad.jtb.core.builders.ApiBuilder;
import io.fouad.jtb.core.builders.InlineKeyboardButtonBuilder;
import io.fouad.jtb.core.builders.KeyboardButtonBuilder;
import io.fouad.jtb.core.builders.ReplyMarkupBuilder;
import io.fouad.jtb.core.enums.ParseMode;
import io.fouad.jtb.core.exceptions.NegativeResponseException;

public class DelayBot implements UpdateHandler
{
	@Override
	public void onCallbackQueryReceived(TelegramBotApi api, int id, CallbackQuery arg2)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onChosenInlineResultReceived(TelegramBotApi api, int id, ChosenInlineResult arg2)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onEditedMessageReceived(TelegramBotApi api, int id, Message arg2)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onGetUpdatesFailure(Exception except)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onInlineQueryReceived(TelegramBotApi api, int id, InlineQuery arg2)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public void onMessageReceived(TelegramBotApi api, int id, Message incomingMessage)
	{
		// TODO Auto-generated method stub
		try
		{
			new ReplyMarkupBuilder();
			ApiBuilder.api(api)
					.sendMessage("#")
					.toChatId(incomingMessage.getChat().getId())
					.applyReplyMarkup(
							ReplyMarkupBuilder.sendCustomKeyboard(
									KeyboardButtonBuilder
									.newRow()
										.newButton("AAAAA")
										.newButton("BBBB")
									.newRow()
										.newButton("").requestLocation()
									.build())
								.toReplyMarkup())
					.execute();
			ApiBuilder.api(api)
					.sendMessage(incomingMessage.getText())
					.toChatId(incomingMessage.getChat().getId())
					.asReplyToMessage(incomingMessage.getMessageId())
					.parseMessageAs(ParseMode.PLAIN).execute();
		} catch (IOException | NegativeResponseException e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
