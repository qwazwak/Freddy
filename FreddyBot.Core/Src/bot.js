var config = JSON.parse(configFile);

// Initialize Swear Jar
SwearJar.init();

// Initialize Discord Commands
const commands = [
	{
		name: "okb",
		description: "OK Boomer a message",
		options: [
			{
				name: "messageid",
				description: "The message ID you wish to OK Boomer",
				type: 3,
				required: true
			}
		]
	},
	{
		name: "8ball",
		description: "Ask the magic 8 ball a question",
		options: [
			{
				name: "question",
				description: "Your question",
				type: 3,
				required: true
			}
		]
	},
	{
		name: "based",
		description: "React to a message with based",
		options: [
			{
				name: "messageid",
				description: "The message ID you wish to BASED",
				type: 3,
				required: true
			}
		]
	}
]
