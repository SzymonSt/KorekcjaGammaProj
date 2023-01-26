.data
sum dword 255
.code

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