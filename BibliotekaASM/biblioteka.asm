.model flat, stdcall

.data
    gamma real4 2.2
    lookup_table dd 256 dup(0.0)
    temp real4 0.0
    one real4 1.0
    pow_num real4 0.0
    tmp_i_num real4 0.0
    cont real4 255.0

.code
gen_lut proc
    lea edx, lookup_table
    lea eax, gamma
    mov ecx, 255
    movss xmm0, [gamma]
    shufps xmm0,xmm0,0
generate_loop:
    ;movups xmm1, [one]
    ;movups xmm0, [gamma]
    ;divss xmm1, xmm0
    ;movups [pow_num], xmm1

    movups xmm1, [temp]
    ;movups xmm0, [cont]
    ;divss xmm1, xmm0
    movups [edx], xmm1

    ;movups xmm1, [tmp_i_num]
    ;movups xmm0, [pow_num]
    ;mulps xmm1, xmm0
    ;movups [edx], xmm1

    movss xmm2, [temp]
    addss xmm2, [one]
    movss [temp], xmm2

    add edx, 4
    dec ecx
    jnz generate_loop
    lea eax, lookup_table
    ret

gen_lut endp
END