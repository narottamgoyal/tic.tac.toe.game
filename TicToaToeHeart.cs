namespace TIC_TAC_TOE
{
    //  A  | B  | C
    // -------------
    //  D  | E  | F
    // -------------
    //  G  | H  | I
    class Token
    {
        public static string[] Strike = { "ABC", "DEF", "GHI", "ADG", "BEH", "CFI", "CEG", "AEI" };

        public static string[] PossibleMoves = { "AB","AC","AD","AE","AG","AI",
                                                  "BC","BE","BH",
                                                  "CE","CG","CI","CF",
                                                  "DG","DE","DF",
                                                  "EF","EG","EH","EI",
                                                  "FI",
                                                  "GH","GI","GC",
                                                  "HI"
                                                };
        public static string[] RemainingMoves = { "C","B","G","I","D","E",
                                                  "A","H","E",
                                                  "G","E","F","I",
                                                  "A","F","E",
                                                  "D","C","B","A",
                                                  "C",
                                                  "I","H","E",
                                                  "G"
                                                };
    }
}
