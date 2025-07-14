| Method                          | numberFormat         | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |---------:|---------:|---------:|-------:|----------:|
| AddSeparatorsNoSpans            | 1234567890           | 28.93 ns | 0.545 ns | 0.455 ns | 0.0060 |     104 B |
| AddSeparatorsSpansNoStackallock | 1234567890           | 29.29 ns | 0.615 ns | 1.566 ns | 0.0060 |     104 B |
| AddSeparatorsSpansStackallock   | 1234567890           | 28.42 ns | 0.577 ns | 0.593 ns | 0.0028 |      48 B |

| AddSeparatorsNoSpans            | 12345678901234567890 | 41.43 ns | 0.881 ns | 1.114 ns | 0.0093 |     160 B |
| AddSeparatorsSpansNoStackallock | 12345678901234567890 | 43.14 ns | 0.325 ns | 0.272 ns | 0.0093 |     160 B |
| AddSeparatorsSpansStackallock   | 12345678901234567890 | 42.29 ns | 0.871 ns | 2.234 ns | 0.0046 |      80 B |

| AddSeparatorsNoSpans            | 12345(...)67890 [40] | 73.05 ns | 1.454 ns | 2.086 ns | 0.0153 |     264 B |
| AddSeparatorsSpansNoStackallock | 12345(...)67890 [40] | 74.80 ns | 1.450 ns | 1.357 ns | 0.0153 |     264 B |
| AddSeparatorsSpansStackallock   | 12345(...)67890 [40] | 68.23 ns | 1.923 ns | 5.610 ns | 0.0074 |     128 B |