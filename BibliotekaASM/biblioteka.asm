.data
multip real4 255.0
.code

gen_lut proc
movups xmm1, [rdx]
movups xmm0, [rcx]
movups [rsp+16], xmm0
fld real4 ptr [rsp+16]
movups [rsp+16], xmm1
fld real4 ptr[rsp+16]
fyl2x		;x*log2(y)
fld1		;st(0)=1
fld st(1)   ;st(0)=st(1), st(1)=1
fprem		;st(0)%st(1)
f2xm1		;2^st(0)-1
fadd		;st(0)++
fscale		;approx to power of 2
fstp REAL4 ptr [rsp+16]
fstp st(0)
movss xmm1, REAL4 ptr [rsp+16]
mulps xmm1, [multip]
movups [rdx], xmm1
movups [rcx], xmm0
ret
gen_lut endp

gamma_correction proc

movups xmm0, [rcx]
movups xmm1, [rdx]
movups xmm2, [r8]

mov rax,[RSP+48]  
movups xmm2, [rax]
movups [r8], xmm2

mov rax, [RSP+40]
movups xmm1, [rax]
movups [rdx], xmm1

movups xmm0, [r9]
movups [rcx], xmm0

ret
gamma_correction endp
END