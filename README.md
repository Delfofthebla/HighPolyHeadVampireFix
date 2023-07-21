# HighPolyHeadVampireFix
A Synthesis patcher for Skyrim that applies the High Poly Head Vampire Fix to your vampire races dynamically, instead of requiring an ESP to accomplish it.

### Justification
The problem with the original HighPolyHeadVampireFix, is that it's an esp that touches races. Anyone with a decent sized modlist has likely felt the pain, and the reality. Way too many fuckin plugins touch races. Races are very large forms within skyrim, and Bash/Smash patches can only do so much.

This synthesis patch gives you the ability to just do what that fix is doing, but as a singular change applied to the race record based on what was at the end of your loadorder. Provided that you are already solving other conflict issues elsewhere, this patch can help you achieve maximum compatibility. 

### Instructions

Disable (or delete) any and ALL HighPolyHeadVampireFix esps in your loadorder, then add this patch to the end of your Synthesis patch group that handles NPCS. If you only use one synthesis patch group, that should be fine too.

This patcher _should_ work on any custom races that you have added, provided that they have "Vampire" in their name, and need the fix. I have not tested this however so create a gitub issue in this repo if you see any compatibility problems.