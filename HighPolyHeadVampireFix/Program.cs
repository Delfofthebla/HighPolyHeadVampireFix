using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;

namespace HighPolyHeadVampireFix
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
            => await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .Run(args);

        private static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            Console.WriteLine("**************************************");
            Console.WriteLine("Before running this patcher, ensure that you disable any and ALL 'High Poly Head Vampire Fix' esps or patches, as they are no longer needed.");
            Console.WriteLine("Do NOT disable them -after- running this patcher. Disable them -BEFORE- you run this.");
            Console.WriteLine("You can keep them if you REALLY want to, but I don't recommend it unless you know what you are doing.");
            Console.WriteLine("**************************************");
            foreach (IRaceGetter winningOverride in state.LoadOrder.PriorityOrder.OnlyEnabled().Race().WinningOverrides())
            {
                if (winningOverride.EditorID == null || !winningOverride.EditorID.Contains("Vampire", StringComparison.InvariantCultureIgnoreCase))
                    continue;
                
                Race.Flag modifiedFlags = winningOverride.Flags & ~Race.Flag.OverlayHeadPartList; // Remove the flag from the record.
                if (modifiedFlags == winningOverride.Flags)
                    continue;

                Race raceToPatch = state.PatchMod.Races.GetOrAddAsOverride(winningOverride);
                raceToPatch.Flags = modifiedFlags;
                Console.WriteLine("Applied the Vampire Head Fix to the '" + winningOverride.Name + "' race.");
            }

            Console.WriteLine("High Poly Vampire Head Fix Applied to all necessary races.");
        }
    }
}
