.model flat, stdcall

.data
    align 16
    gamma DWORD 2.2
    lookup_table dword 256 dup(0) 

.code
gen_lut proc
    ; Load gamma correction factor into xmm0 register
    movss xmm0, [gamma]

    ; Load lookup table into xmm1 register
    movups xmm1, [lookup_table]

    ; Loop to generate lookup table values
    mov ecx, 256
generate_loop:
    ; Multiply current value in lookup table with gamma correction factor
    mulps xmm1, xmm0

    ; Store result back in lookup table
    movups [lookup_table], xmm1

    ; Increment the pointer to the next value in the lookup table
    add dword ptr [lookup_table], 4

    ; Decrement the counter
    dec ecx

    ; Check if the counter is zero
    jnz generate_loop

    lea eax, [lookup_table]

    ; Return the lookup table
    ret

gen_lut endp
END