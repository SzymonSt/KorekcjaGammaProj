
.code

gamma_correction proc

movups xmm0, [rcx]
movups xmm1, [rdx]

;movups xmm0, [r8] ; wpisywanie elementow 1 tab do xmm0
addps xmm0, xmm1; dodanie dwoch rejestrow
movups [rax], xmm0; przeniesienie wynikow do tablicy wynikowej

ret
gamma_correction endp
END