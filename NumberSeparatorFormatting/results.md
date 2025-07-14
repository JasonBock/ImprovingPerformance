| Method                          | numberFormat         | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------------------------------- |--------------------- |---------:|---------:|---------:|-------:|----------:|
| AddSeparatorsNoSpans            | 1234567890           | 15.39 ns | 0.266 ns | 0.235 ns | 0.0060 |     104 B |
| AddSeparatorsSpansNoStackallock | 1234567890           | 15.52 ns | 0.115 ns | 0.102 ns | 0.0060 |     104 B |
| AddSeparatorsSpansStackallock   | 1234567890           | 12.89 ns | 0.117 ns | 0.109 ns | 0.0028 |      48 B |

| AddSeparatorsNoSpans            | 12345678901234567890 | 20.67 ns | 0.096 ns | 0.085 ns | 0.0093 |     160 B |
| AddSeparatorsSpansNoStackallock | 12345678901234567890 | 21.49 ns | 0.099 ns | 0.093 ns | 0.0093 |     160 B |
| AddSeparatorsSpansStackallock   | 12345678901234567890 | 19.88 ns | 0.373 ns | 0.349 ns | 0.0046 |      80 B |

| AddSeparatorsNoSpans            | 12345(...)67890 [40] | 34.72 ns | 0.271 ns | 0.241 ns | 0.0153 |     264 B |
| AddSeparatorsSpansNoStackallock | 12345(...)67890 [40] | 39.39 ns | 0.303 ns | 0.268 ns | 0.0153 |     264 B |
| AddSeparatorsSpansStackallock   | 12345(...)67890 [40] | 37.13 ns | 0.288 ns | 0.270 ns | 0.0074 |     128 B |

| AddSeparatorsNoSpans            | 12345(...)67890 [80] | 68.38 ns | 0.533 ns | 0.473 ns | 0.0278 |     480 B |
| AddSeparatorsSpansNoStackallock | 12345(...)67890 [80] | 68.64 ns | 0.425 ns | 0.377 ns | 0.0278 |     480 B |
| AddSeparatorsSpansStackallock   | 12345(...)67890 [80] | 65.44 ns | 0.394 ns | 0.369 ns | 0.0138 |     240 B |