using System;
using System.Drawing;
using MediaMallTechnologies.PlayOn.Plugin;

namespace PBSKidsPlayOn
{

	/// <summary>
	/// This is the required settings class for describing important details about your plugin.  Here you can
	/// specify various metadata information in the Settings attribute.  You can also set the type of objects 
	/// that your plugin will use to store custom settings/options.  Additionally there are methods available 
	/// for overriding that can be used to handle initialization, update checks, login verifies and provide
	/// settings/options controls and/or forms for the user to edit your custom settings/options with.
	/// </summary>
	[Settings(
		"PBS Kids",
		"PBSKidsID",
		"PBS Kids shows children educational videos created for the Public Broadcasting Corporation",
		"res://PBSKidsPlayOn.logo.png",
		"http://www.pbskids.org/",
		false,
		null)
	]
	class PBSKidsSettings : PluginSettings
	{
	}

	/// <summary>
	/// This is the required director class when using PlayDirect that controls how PlayDirect functions.
	/// The Director attribute associates this director class with the settings class making your settings
	/// easily accessible from within.  This class has methods available for overriding that control how
	/// large the web browser window will be, how big the target player should be when it is being searched
	/// for, what the interesting/viewing area of the player is and when it is found.  It also provides the 
	/// ability to zoom the player to a more reasonable size (may not be supported on all systems).
	/// </summary>
	[Director(typeof(PBSKidsSettings))]
	class PBSKidsDirector : PluginDirector
	{
        const int rightSidebarWidth = 120;
        const int topNavHeight = 120;
        const int bottomNavHeight = 127;

        /// <summary>
        /// Browser Size
        /// </summary>
        /// <remarks>Let's try to get as close as possible to 1280 by 724</remarks>
        public override Size BrowserSize => new Size(1280 + rightSidebarWidth, 724 + topNavHeight + bottomNavHeight);

        /// <summary>
        /// Retrieve the Player Viewing Rectangle
        /// </summary>
        /// <param name="playerSize"></param>
        /// <returns>Rectangle in relation to the Browser Window to Show the Player</returns>
        public override Rectangle GetPlayerViewingRectangle(Size playerSize)
        {
            return new Rectangle(6, 120, 1280, 724);
        }

        /// <summary>
        /// Called when the player matching the search criteria has been found.
        /// </summary>
        /// <param name="player">HWND of the player</param>
        public override void OnPlayerFound(IntPtr player)
		{
            // NOTE: SH - We can get direct access to the player by accessing it via document.getElementById('video-player').player.player_; although, we don't currently do this.

            // Hide the player cruft
            ExecuteScriptBlock("document.getElementById('browsing-panel').style.display = 'none';document.getElementsByClassName('brand')[0].style.display = 'none';document.getElementsByClassName('vjs-control-bar')[0].style.display = 'none';");

            // Abort auto play and tell playon to stop
            ExecuteScriptBlock("PBSKidsPlayerEvents.on('VOD_MEDIA_END', function() {window.PBSKidsPlayerEvents.emit(window.PBSKidsPlayerEvents.UNLOAD_PLAYER);});");
        }
    }

	/// <summary>
	/// This is the required provider class that provides access to content through a virtual filesystem.
	/// The Provider attribute associates the settings and optional director classes with the provider
	/// making your settings easily accessible from within.  This class has methods required for overriding
	/// that control how folders are loaded and how files are played back.
	/// </summary>
	[Provider(typeof(PBSKidsSettings), typeof(PBSKidsDirector))]
	class PBSKidsProvider : PluginProvider
	{
        ContentSource[] sources;

        /// <summary>
        /// Constructor
        /// </summary>
        public PBSKidsProvider()
        {
            sources = new ContentSource[]
            {
                new ContentSource
                {
                    Name = "Arthur",
                    BaseVideoUrl = "https://pbskids.org/video/arthur/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/arthur"
                },
                new ContentSource
                {
                    Name = "Caillou",
                    BaseVideoUrl = "https://pbskids.org/video/caillou/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/caillou"
                },
                new ContentSource
                {
                    Name = "Cat in the Hat",
                    BaseVideoUrl = "https://pbskids.org/video/cat-in-the-hat/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/cat-in-the-hat"
                },
                new ContentSource
                {
                    Name = "Curious George",
                    BaseVideoUrl = "https://pbskids.org/video/curious-george/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/curious-george.json"
                },
                new ContentSource
                {
                    Name = "Cyberchase",
                    BaseVideoUrl = "https://pbskids.org/video/cyberchase/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/cyberchase"
                },
                new ContentSource
                {
                    Name = "Daniel Tiger's Neighborhood",
                    BaseVideoUrl = "http://pbskids.org/video/daniel-tigers-neighborhood/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/daniel-tigers-neighborhood.json"
                },
                new ContentSource
                {
                    Name = "Design Squad",
                    BaseVideoUrl = "https://pbskids.org/video/design-squad-nation/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/design-squad-nation"
                },
                new ContentSource
                {
                    Name = "Dinosaur Train",
                    BaseVideoUrl = "https://pbskids.org/video/dinosaur-train/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/dinosaur-train"
                },
                new ContentSource
                {
                    Name = "Fizzy's Lunch Lab",
                    BaseVideoUrl = "https://pbskids.org/video/fizzys-lunch-lab/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/fizzys-lunch-lab"
                },
                new ContentSource
                {
                    Name = "Let's Go Luna",
                    BaseVideoUrl = "https://pbskids.org/video/lets-go-luna/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/lets-go-luna.json"
                },
                new ContentSource
                {
                    Name = "Martha Speaks",
                    BaseVideoUrl = "https://pbskids.org/video/martha-speaks/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/martha-speaks"
                },
                new ContentSource
                {
                    Name = "Mister Rogers",
                    BaseVideoUrl = "https://pbskids.org/video/mister-rogers/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/mister-rogers"
                },
                new ContentSource
                {
                    Name = "Molly of Denali",
                    BaseVideoUrl = "https://pbskids.org/video/molly-of-denali/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/molly-of-denali"
                },
                new ContentSource
                {
                    Name = "Nature Cat",
                    BaseVideoUrl = "https://pbskids.org/video/nature-cat/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/nature-cat"
                },
                new ContentSource
                {
                    Name = "Odd Squad",
                    BaseVideoUrl = "https://pbskids.org/video/odd-squad/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/odd-squad.json"
                },
                new ContentSource
                {
                    Name = "Oh Noah!",
                    BaseVideoUrl = "https://pbskids.org/video/oh-noah/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/oh-noah"
                },
                new ContentSource
                {
                    Name = "The Ruff Ruffman Show",
                    BaseVideoUrl = "https://pbskids.org/video/ruff-ruffman-show/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/ruff-ruffman-show"
                },
                new ContentSource
                {
                    Name = "Peg + Cat",
                    BaseVideoUrl = "https://pbskids.org/video/peg/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/peg"
                },
                new ContentSource
                {
                    Name = "Pinkalicious and Peterrific",
                    BaseVideoUrl = "https://pbskids.org/video/pinkalicious-and-peterrific/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/pinkalicious-and-peterrific.json"
                },
                new ContentSource
                {
                    Name = "Plum Landing",
                    BaseVideoUrl = "https://pbskids.org/video/plum-landing/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/plum-landing"
                },
                new ContentSource
                {
                    Name = "Ready Jet Go!",
                    BaseVideoUrl = "https://pbskids.org/video/ready-jet-go/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/ready-jet-go"
                },
                new ContentSource
                {
                    Name = "Sesame Street",
                    BaseVideoUrl = "https://pbskids.org/video/sesame-street/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/sesame-street.json"
                },
                new ContentSource
                {
                    Name = "SciGirls",
                    BaseVideoUrl = "https://pbskids.org/video/scigirls/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/scigirls"
                },
                new ContentSource
                {
                    Name = "Sid the Science Kid",
                    BaseVideoUrl = "https://pbskids.org/video/sid-science-kid/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/sid-science-kid"
                },
                new ContentSource
                {
                    Name = "Splash and Bubbles",
                    BaseVideoUrl = "https://pbskids.org/video/splash-and-bubbles/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/splash-and-bubbles"
                },
                new ContentSource
                {
                    Name = "Super Why",
                    BaseVideoUrl = "https://pbskids.org/video/super-why/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/super-why"
                },
                new ContentSource
                {
                    Name = "Wild Kratts",
                    BaseVideoUrl = "https://pbskids.org/video/wild-kratts/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/wild-kratts.json"
                },
                new ContentSource
                {
                    Name = "WordGirl",
                    BaseVideoUrl = "https://pbskids.org/video/wordgirl/",
                    JsonUrl = "https://content.services.pbskids.org/v2/kidspbsorg/programs/wordgirl"
                },
                new ContentSource
                {
                    Name = "Word World",
                    BaseVideoUrl = "https://pbskids.org/video/word-world/",
                    JsonUrl = "https://cms-tc.pbskids.org/pbskidsvideoplaylists/word-world.json"
                }
            };
        }


		/// <summary>
		/// Called when a dynamic virtual folder is browsed to and allows it to be loaded if needed.
		/// The Root folder is always dynamic to permit on demand first time loading.
		/// </summary>
		/// <param name="vf">VirtualFolder that is being loaded (currently browsed to).</param>
		protected override void LoadDynamicVirtualFolder(VirtualFolder vf)
		{
			// We need to load the root folder as a special case
			if (vf == VFS.Root)
			{
                // Don't reload Root ever again
                vf.Dynamic = true;

                var service = new FullEpisodeService(new PlayOnHttpClient());

                foreach (var source in sources)
                {
                    VirtualFolder vfc = VFS.CreateFolder(vf, source.Name, "", true);
                    var playlist = service.FetchPlaylist(source.JsonUrl);
                    foreach (var item in playlist.Collections.Episodes.Content)
                    {
                        VFS.CreateVideoFile(vfc, item.Title, source.BaseVideoUrl + item.Id, item.Description, item.Images != null ? item.Images.Mezzanine : null, item.AirDate.Date, source.BaseVideoUrl + item.Id, null, item.DurationSeconds * 1000, 0, null, null);
                    }
                }
            }
		}

		/// <summary>
		/// Creates the PlaybackDescriptor for a VirtualVideoFile.  This is called when the 
		/// user attempts to plays the item.
		/// </summary>
		/// <param name="vvf">VirtualVideoFile the user attempted to play.</param>
		/// <returns>A PlaybackDescriptor instance that describes the item to play.</returns>
		protected override PlaybackDescriptor CreatePlaybackDescriptor(VirtualVideoFile vvf)
		{
			// Since this is flash media we use FlastDirect.
			PlaybackDescriptor pd = new PlaybackDescriptor(vvf.Path, MediaFormat.HTML5);
			pd.AudioAbortInterval = 10; // Time in seconds that must pass without audio before stopping
			pd.VideoAbortInterval = 10; // Time in seconds that must pass without video before stopping
			return pd;
		}
	}
}
