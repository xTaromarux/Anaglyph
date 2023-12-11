.code

CheckMMX proc
    mov eax, 1
    cpuid
    test edx, 00800000h
    jnz MMX_Supported
    xor eax, eax
    jmp Done
MMX_Supported:
    mov eax, 1
Done:
    ret
CheckMMX endp

CheckSSE proc
    mov eax, 1
    cpuid
    test edx, 02000000h
    jnz SSE_Supported
    xor eax, eax
    jmp Done
SSE_Supported:
    mov eax, 1
Done:
    ret
CheckSSE endp

CheckSSE2 proc
    mov eax, 1
    cpuid
    test edx, 04000000h
    jnz SSE2_Supported
    xor eax, eax
    jmp Done
SSE2_Supported:
    mov eax, 1
Done:
    ret
CheckSSE2 endp

CheckSSE3 proc
    mov eax, 1
    cpuid
    test ecx, 00000001h
    jnz SSE3_Supported
    xor eax, eax
    jmp Done
SSE3_Supported:
    mov eax, 1
Done:
    ret
CheckSSE3 endp

end
