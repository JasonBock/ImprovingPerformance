# Concatenation Results

## Concatenation3Parts

### .NET 4.8.1

| Method                       | Mean      | Error    | StdDev   | Ratio | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |----------:|---------:|---------:|------:|-------:|-------:|----------:|------------:|
| ConcatenateWithAddition      |  54.36 ns | 0.209 ns | 0.195 ns |  1.00 | 0.1020 |      - |     642 B |        1.00 |
| ConcatenateWithStringBuilder | 120.34 ns | 0.317 ns | 0.296 ns |  2.21 | 0.2511 | 0.0010 |    1581 B |        2.46 |
| ConcatenateWithInterpolation |  54.06 ns | 0.155 ns | 0.145 ns |  0.99 | 0.1020 |      - |     642 B |        1.00 |

### .NET 9

| Method                       | Mean     | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |---------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| ConcatenateWithAddition      | 32.44 ns | 0.290 ns | 0.271 ns |  1.00 |    0.01 | 0.0329 |      - |     568 B |        1.00 |
| ConcatenateWithStringBuilder | 85.17 ns | 0.504 ns | 0.471 ns |  2.63 |    0.03 | 0.0908 | 0.0004 |    1568 B |        2.76 |
| ConcatenateWithInterpolation | 39.55 ns | 0.203 ns | 0.180 ns |  1.22 |    0.01 | 0.0292 |      - |     504 B |        0.89 |

## Concatenation9Parts

### .NET 4.8.1

| Method                       | Mean     | Error   | StdDev  | Ratio | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |---------:|--------:|--------:|------:|-------:|-------:|----------:|------------:|
| ConcatenateWithAddition      | 164.1 ns | 0.86 ns | 0.80 ns |  1.00 | 0.2880 |      - |   1.77 KB |        1.00 |
| ConcatenateWithStringBuilder | 304.2 ns | 1.11 ns | 1.04 ns |  1.85 | 0.5522 | 0.0038 |   3.39 KB |        1.92 |
| ConcatenateWithInterpolation | 164.1 ns | 0.30 ns | 0.25 ns |  1.00 | 0.2880 |      - |   1.77 KB |        1.00 |

### .NET 9

| Method                       | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| ConcatenateWithAddition      |  95.03 ns | 0.322 ns | 0.285 ns |  1.00 |    0.00 | 0.0955 |      - |   1.61 KB |        1.00 |
| ConcatenateWithStringBuilder | 174.83 ns | 1.814 ns | 1.697 ns |  1.84 |    0.02 | 0.2007 | 0.0014 |   3.38 KB |        2.10 |
| ConcatenateWithInterpolation | 133.29 ns | 0.847 ns | 0.707 ns |  1.40 |    0.01 | 0.0861 |      - |   1.45 KB |        0.90 |

## Concatenation30Parts

### .NET 4.8.1

| Method                       | Mean       | Error   | StdDev  | Ratio | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |-----------:|--------:|--------:|------:|-------:|-------:|----------:|------------:|
| ConcatenateWithAddition      |   547.5 ns | 2.12 ns | 1.98 ns |  1.00 | 0.9413 | 0.0010 |   5.79 KB |        1.00 |
| ConcatenateWithStringBuilder | 1,013.6 ns | 7.45 ns | 6.97 ns |  1.85 | 1.9245 | 0.0496 |  11.83 KB |        2.04 |
| ConcatenateWithInterpolation |   552.2 ns | 4.48 ns | 4.19 ns |  1.01 | 0.9413 | 0.0010 |   5.79 KB |        1.00 |

### .NET 9

| Method                       | Mean     | Error   | StdDev  | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |---------:|--------:|--------:|------:|--------:|-------:|-------:|----------:|------------:|
| ConcatenateWithAddition      | 314.9 ns | 3.73 ns | 3.30 ns |  1.00 |    0.01 | 0.3133 | 0.0005 |   5.28 KB |        1.00 |
| ConcatenateWithStringBuilder | 541.4 ns | 3.31 ns | 3.10 ns |  1.72 |    0.02 | 0.7000 | 0.0181 |  11.79 KB |        2.23 |
| ConcatenateWithInterpolation | 357.6 ns | 1.33 ns | 1.18 ns |  1.14 |    0.01 | 0.2847 |      - |    4.8 KB |        0.91 |

## Concatenation300Parts

### .NET 4.8.1

| Method                       | Mean     | Error     | StdDev    | Ratio | Gen0    | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| ConcatenateWithAddition      | 5.456 us | 0.0301 us | 0.0281 us |  1.00 |  9.2850 | 0.1068 |  57.34 KB |        1.00 |
| ConcatenateWithStringBuilder | 9.612 us | 0.0277 us | 0.0259 us |  1.76 | 17.2272 | 2.8687 | 106.24 KB |        1.85 |
| ConcatenateWithInterpolation | 5.404 us | 0.0128 us | 0.0114 us |  0.99 |  9.2850 | 0.1068 |  57.34 KB |        1.00 |

### .NET 9

| Method                       | Mean     | Error     | StdDev    | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|----------------------------- |---------:|----------:|----------:|------:|--------:|-------:|-------:|----------:|------------:|
| ConcatenateWithAddition      | 3.262 us | 0.0473 us | 0.0443 us |  1.00 |    0.02 | 3.1128 | 0.0534 |  52.57 KB |        1.00 |
| ConcatenateWithStringBuilder | 5.282 us | 0.0489 us | 0.0457 us |  1.62 |    0.03 | 6.2866 | 1.0452 | 106.09 KB |        2.02 |
| ConcatenateWithInterpolation | 4.530 us | 0.0381 us | 0.0356 us |  1.39 |    0.02 | 2.8305 |      - |  47.87 KB |        0.91 |