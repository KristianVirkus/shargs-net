namespace Shargs.UnitTests.Data1
{
    using Shargs.Mapping;

    class ProcessOptions
    {
        [ShortOption('i', Prefix: "-|/", OptionValueSeparators: "=|:", QuotationMarks: "\"" )]
        [LongOption("input", Prefix: "--|/")]
        [OptionDescription("The input file path")]
        [OptionDescription("Dateipfad der Eingabedatei")]
        public StringOption InputFile { get; set; }

        [ShortOption('o', Prefix: "-|/")]
        [LongOption("output", Prefix: "--|/")]
        [OptionDescription("The output file path")]
        [OptionDescription("Dateipfad der Ausgabedatei")]
        public string OutputFile { get; set; }
    }
}
