.model flat, stdcall

.data
    gamma real4 2.2
    lookup_table db 256 dup(0.0)
    temp real4 0.0
    one real4 1.0
    pow_num real4 0.0

.code
gen_lut proc
    lea edx, lookup_table
    lea eax, gamma
    mov ecx, 256
    movss xmm0, [gamma]
    shufps xmm0,xmm0,0
generate_loop:
    movups xmm1, [one]
    divss xmm1, xmm0
    movups pow_num, xmm1

    movups xmm1, [temp]
    mulps xmm1, xmm0
    movups [edx], xmm1

    movss xmm0, [temp]
    addss xmm0, [one]
    movss [temp], xmm0

    add edx, 4
    dec ecx
    jnz generate_loop
    ret

gen_lut endp
END