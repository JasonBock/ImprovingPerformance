# .NET 6

|            Method |      Mean |     Error |    StdDev | Allocated |
|------------------ |----------:|----------:|----------:|----------:|
|   CastUsingCSharp | 0.2905 ns | 0.0397 ns | 0.0372 ns |         - |
| CastUsingUnsafeAs | 0.0000 ns | 0.0000 ns | 0.0000 ns |         - |

## .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short M00_L00
       mov       rcx,offset MT_UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short M00_L01
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      CORINFO_HELP_CHKCASTCLASS_SPECIAL
       int       3
; Total bytes of code 42
```

## .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```


# .NET 7

|            Method |      Mean |     Error |    StdDev | Allocated |
|------------------ |----------:|----------:|----------:|----------:|
|   CastUsingCSharp | 1.2280 ns | 0.0521 ns | 0.0488 ns |         - |
| CastUsingUnsafeAs | 0.9835 ns | 0.0618 ns | 0.0578 ns |         - |

## .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short M00_L00
       mov       rcx,offset MT_UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short M00_L01
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      qword ptr [7FF978FDB8B8]
       int       3
; Total bytes of code 43
```

## .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```


# .NET 8

| Method              | Mean      | Error     | StdDev    | Code Size | Allocated |
|-------------------- |----------:|----------:|----------:|----------:|----------:|
| CastUsingCSharp     | 0.7289 ns | 0.0176 ns | 0.0164 ns |     116 B |         - |
| CastUsingUnsafeAs   | 0.5277 ns | 0.0181 ns | 0.0170 ns |       5 B |         - |

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short M00_L00
       mov       rcx,offset MT_UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short M00_L01
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      qword ptr [7FFA436843F0]; System.Runtime.CompilerServices.CastHelpers.ChkCastClassSpecial(Void*, System.Object)
       int       3
; Total bytes of code 43
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.ChkCastClassSpecial(Void*, System.Object)
       mov       rax,[rdx]
M01_L00:
       mov       rax,[rax+10]
       cmp       rax,rcx
       jne       short M01_L02
M01_L01:
       mov       rax,rdx
       ret
M01_L02:
       test      rax,rax
       je        short M01_L03
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M01_L01
       test      rax,rax
       je        short M01_L03
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M01_L01
       test      rax,rax
       je        short M01_L03
       mov       rax,[rax+10]
       cmp       rax,rcx
       je        short M01_L01
       test      rax,rax
       jne       short M01_L00
M01_L03:
       lea       rax,[7FFAA302A8C8]
       jmp       qword ptr [rax]
; Total bytes of code 73
```

## .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```

# .NET 9

| Method              | Mean      | Error     | StdDev    | Code Size | Allocated |
|-------------------- |----------:|----------:|----------:|----------:|----------:|
| CastUsingCSharp     | 0.7382 ns | 0.0201 ns | 0.0188 ns |      62 B |         - |
| CastUsingUnsafeAs   | 0.5259 ns | 0.0106 ns | 0.0099 ns |       5 B |         - |

## .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingCSharp()
       sub       rsp,28
       mov       rdx,[rcx+8]
       mov       rax,rdx
       test      rax,rax
       je        short M00_L00
       mov       rcx,offset MT_UsingUnsafeAs.TargetType
       cmp       [rax],rcx
       jne       short M00_L01
M00_L00:
       add       rsp,28
       ret
M00_L01:
       call      System.Runtime.CompilerServices.CastHelpers.ChkCastClass(Void*, System.Object)
       int       3
; Total bytes of code 42
```
```assembly
; System.Runtime.CompilerServices.CastHelpers.ChkCastClass(Void*, System.Object)
       test      rdx,rdx
       je        short M01_L00
       cmp       [rdx],rcx
       jne       short M01_L01
M01_L00:
       mov       rax,rdx
       ret
M01_L01:
       jmp       qword ptr [7FFBE0504AF8]; System.Runtime.CompilerServices.CastHelpers.ChkCastClassSpecial(Void*, System.Object)
; Total bytes of code 20
```

## .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
```assembly
; UsingUnsafeAs.CastingObjects.CastUsingUnsafeAs()
       mov       rax,[rcx+8]
       ret
; Total bytes of code 5
```