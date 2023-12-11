.code

matrix_multiply proc
    ; Parameters:
    ; [rdi] - matrix1
    ; [rsi] - matrix2
    ; [rdx] - result

    ; Initialize variables
    xorpd xmm4, xmm4       ; Clear xmm4 to store the result for the current row
    xor rax, rax           ; rax will be used for outer loop counters

    ; Outer loop (rows of matrix1)
    outer_loop:
        mov rcx, 0          ; rcx will be used for inner loop counters

        ; Inner loop (columns of matrix2)
        inner_loop:
            movsd xmm0, qword ptr [rdi + rax * 8]       ; Load matrix1 element to xmm0
            movsd xmm1, qword ptr [rsi + rcx * 8]       ; Load matrix2 element to xmm1
            mulsd xmm1, xmm0                            ; Multiply matrix1 and matrix2 elements
            addsd xmm4, xmm1                            ; Add the result to xmm4

            inc rcx                                     ; Move to the next column of matrix2
            cmp rcx, 1                                  ; Check if inner loop is done (assuming matrix2 is 3x3)
            jl inner_loop
        ; End of inner loop

        ; Store the result in the result matrix
        movsd qword ptr [rdx + rax * 8], xmm4
        xorpd xmm4, xmm4      ; Clear xmm4 for the next iteration
        inc rax               ; Move to the next row of matrix1
        cmp rax, 3            ; Check if outer loop is done (assuming matrix1 is 3x3)
        jl outer_loop
    ; End of outer loop

    ret
matrix_multiply endp

end
    