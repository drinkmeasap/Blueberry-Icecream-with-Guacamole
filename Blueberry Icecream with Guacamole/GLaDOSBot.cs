using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Blueberry_Icecream_with_Guacamole
{
    class GLaDOSBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] meMes;

        public GLaDOSBot()
        {

            rand = new Random();

            meMes = new string[]
            {
                "Memes/child.jpg",
                "Memes/chooseyouclass.jpg",
                "Memes/floor.png",
                "Memes/legonsfw.png",
                "Memes/racist.jpg",
                "Memes/rust.jpg",
                "Memes/skinner.jpg",
                "Memes/uber.jpg",
                "Memes/meme1.jpg",
                "Memes/meme2.jpg",
                "Memes/meme3.jpg",
                "Memes/meme4.jpg",
                "Memes/meme5.jpg",
                "Memes/meme6.jpg",
                "Memes/meme7.jpg"

            };



            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '<';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            // Commands go here V

            #region HiCommand
            commands.CreateCommand("hi")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("Hey, moron!");
                });
            #endregion
               
            #region Help
            commands.CreateCommand("help")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Available commands: \n <hi \n <ping \n <sound \n <info \n <meme \n <clear \n <roll or <ttsroll \n <gas \n <suicide \n <sourcecode \n if you are blind you can do <ttshelp");
                });
            #endregion


            #region TTSHelp
            commands.CreateCommand("ttshelp")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("Available commands: ");
                    await e.Channel.SendTTSMessage("\n hi \n ping \n sound \n info \n meme \n clear \n roll or ttsroll \n gas \n suicide \n sourcecode");
                });
            #endregion

            #region Info
            commands.CreateCommand("info")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("GLaDOS bot is made by: \n @Haven#7682 and @Wilswe#0440");
                });
            #endregion

            #region Sound
            commands.CreateCommand("sound")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("This function is FUCKING DISABLED OH MY GOD!");
                });
            #endregion

            #region Suicide Hotline
            commands.CreateCommand("suicide")
                .Do(async (e) =>
                {
                    //await e.Channel.SendMessage("https://upload.wikimedia.org/wikipedia/commons/thumb/2/2e/Luger_P08_%286971793777%29.jpg/1200px-Luger_P08_%286971793777%29.jpg");
                    await e.Channel.SendTTSMessage("It's your old friend, deadly neurotoxin. If I were you, I'd take a deep breath. And hold it.");
                });
            #endregion

            #region gas
            commands.CreateCommand("gas")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("Sprinkler goes thiststststststststststststststststststststststststs");
                });
            #endregion

            #region Name
            commands.CreateCommand("name")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("My name is GLaDOS");
                });
            #endregion

            #region sourcecode
            commands.CreateCommand("sourcecode")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("It's private.");
                });
            #endregion


            #region roll
            commands.CreateCommand("roll")
                .Do(async (e) =>
                {
                    int rollnumber = rand.Next(0, 100);
                    
                    await e.Channel.SendMessage("You rolled " + rollnumber + "!");
                });
            #endregion

            #region ttsroll
            commands.CreateCommand("ttsroll")
                .Do(async (e) =>
                {
                    int rollnumber = rand.Next(0, 100);

                    await e.Channel.SendTTSMessage("You rolled " + rollnumber + "!");
                });
            #endregion

            #region MemeGenerator
            commands.CreateCommand("meme")
                .Do(async (e) =>
                {
                    int randomMemeIndex = rand.Next(meMes.Length);
                    string memeToPost = meMes[randomMemeIndex];
                    await e.Channel.SendFile(memeToPost);
                });
            #endregion

            #region Clear
            commands.CreateCommand("clear")
                .Do(async (e) =>
                {
                    Message[] messagesToClear;
                    messagesToClear = await e.Channel.DownloadMessages(50);
                    await e.Channel.DeleteMessages(messagesToClear);
                });
            #endregion

            #region ping
            commands.CreateCommand("ping")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Pong!");
                });
            #endregion



            discord.ExecuteAndWait(async () =>
            {                      //Token doesn't work there is no point in trying to use it OK?
                await discord.Connect("Token has been removed from here so nobody looking at github will be able to access it, send shits in our channels. Don't bother looking through history cuz we generated a new one already :)", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
    

