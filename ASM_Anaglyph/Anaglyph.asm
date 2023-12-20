.code

    matrix_multiply proc
        ; Parameters:
        ; [rcx] - matrix1 3x3
        ; [rdx] - matrix2 1x3
        ; [r8] - result 1x3

        ; Initialize variables
        xorpd xmm4, xmm4       ; Clear xmm4 to store the result for the current row
        xor rax, rax             ; rax will be used for outer loop counters
        outer_loop:               ; Outer loop (rows of matrix1)
            xor rdi, rdi             ; rax will be used for inner loop counters
            
            cmp rax, 3            ; Check if outer loop is done (assuming matrix1 is 3x3)
            je Done               ; End of outer loop

        inner_loop:                  ; Inner loop (columns of matrix2)
            movdqu xmm0, [rcx]       ; Load matrix1 element to xmm0
            movdqu xmm1, [rdx]       ; Load matrix2 element to xmm1
            pmullw xmm1, xmm0        ; Multiply matrix1 and matrix2 elements
            paddusw xmm4, xmm1       ; Add the result to xmm4

   
            inc rdi                  ; Move to the next column of matrix2
            cmp rdi, 2               ; Check if inner loop is done (assuming matrix2 is 3x3)
            je innerLoopDone         ; End of inner loop
            jmp inner_loop

        innerLoopDone:
           inc rax               ; Move to the next row of matrix1
           movdqu [r8], xmm4     ; Store the result in the result matrix
           xorpd xmm4, xmm4      ; Clear xmm4 for the next iteration
           jmp outer_loop

        Done: 
            ret 

    matrix_multiply endp

end
    