# Realm Client
OpenGL RotMG client made in .NET core  

## Goals
Replicate normal RotMG client functionality  
Replace and exceed the disaster that is Exalt  
Provide a better experience than Exalt  

## Todo
- Rendering toggles for low cpu modes
- Freecam
- Custom sfx, maybe via loading an mp3 inside a SOL, input could be file select or url
- Overhaul chat, fix its bugs
- Get server ping via guildcreate
- Auto disable hacks when near players (optionally ignore guild or locked)
- Locally saved locklist
- Tooltip hover item in chat
- Minimap teleport
- Escape packet for server detection
- Optimize calcVulnerables, only update the npc in question in onUpdate
- Show tooltip of player when hovering name in chat, while holding shift maybe
- Correctly detect current server when reconnecting to a previous realm after switching servers
- Optimize vulnerable enemy list rebuilding (would help performance)
- Fix reconnect menu and reimplement recon
- Finish pathfinding implementation
- Finish multithreading implementation
- Dye/Skin faking
- Client loader
- Check for outdated client
- Load updated client once available
- Auto dungeon runner
- New player client setup/tutorial (legit, minimal, blatant, etc)
- Radial opacity for your player

## Libraries Used
[Silk.NET](https://github.com/dotnet/Silk.NET)  
[ImGui](https://github.com/ocornut/imgui)  
[AssetStudio](https://github.com/Perfare/AssetStudio)  

---

_DECA may not love Realm but I still do_  
_Enjoy ♥_  
