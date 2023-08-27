class BotCommands
{
	static async okBoomer(interaction)
	{
		var msgID = interaction.options.get("messageid", true).value;

		try
		{
			var targetMsg = await interaction.channel.messages.fetch(msgID);
		}
		catch(e)
		{
			msg.reply("That is an invalid message ID or it is not in this channel.");
			return;
		}

		await interaction.deferReply({ephemeral: true});

		await targetMsg.react("🆗");
		await targetMsg.react("🅱️");
		await targetMsg.react("🇴");
		await targetMsg.react("🅾️");
		await targetMsg.react("🇲");
		await targetMsg.react("🇪");
		await targetMsg.react("🇷");

		interaction.editReply({content: "Done", ephemeral: true});
	}

	static async based(interaction)
	{
		var msgID = interaction.options.get("messageid", true).value;

		try
		{
			var targetMsg = await interaction.channel.messages.fetch(msgID);
		}
		catch(e)
		{
			msg.reply("That is an invalid message ID or it is not in this channel.");
			return;
		}

		await interaction.deferReply({ephemeral: true});

		await targetMsg.react("🅱️");
		await targetMsg.react("🇦");
		await targetMsg.react("🇸");
		await targetMsg.react("🇪");
		await targetMsg.react("🇩");

		interaction.editReply({content: "Done", ephemeral: true});
	}

	static eightBall(interaction)
	{
		var msg = interaction.options.get("question", true).value;

		var hash = md5(msg);
		var hashSlice = hash.substr(0, 2);
		var val = parseInt(hashSlice, 16) / 256;
		var resNum = Math.floor(val * this.responses.length);
		var res = this.responses[resNum];
		interaction.reply("Query: " + msg + "\n\nReply: " + res);
	}
};

module.exports=BotCommands