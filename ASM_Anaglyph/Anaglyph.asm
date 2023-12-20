.code

    matrix_multiply proc
        ; Parameters:
        ; [rcx] - matrix1 3x3
        ; [rdx] - matrix2 1x3
        ; [r8] - result 1x3

        ; Initialize variables
        xor rax, rax                                ; rax will be used for outer loop counters
        mov r10, 0                                  ; r10 will be used for index counter
        outer_loop:                                 ; Outer loop (rows of matrix1)
            mov rbx, 0                              ; Clear rbx for the next iteration
            xorpd xmm2, xmm2                        ; Clear xmm2 for the next iteration

            cmp rax, 3                              ; Check if outer loop is done (assuming matrix1 is 3x3)
            je Done                                 ; End of outer loop

            inner_loop:                             ; Inner loop (columns of matrix2)
                movupd xmm0, [rcx + r10*8]          ; Load matrix1 element to xmm0
                movupd xmm1, [rdx + rbx*8]          ; Load matrix2 element to xmm1
                mulpd xmm1, xmm0                    ; Multiply matrix1 and matrix2 elements
                addpd xmm2, xmm1                    ; Add the result to xmm2

                inc r10                             ; Move to the next column of matrix1
                inc rbx                             ; Move to the next column of matrix2
                cmp rbx, 1                          ; Check if inner loop is done
                je innerLoopDone                    ; End of inner loop
                jmp inner_loop                      ; Continue inner loop

        innerLoopDone:
           movupd [r8], xmm2                        ; Store the result in the result matrix
           inc rax                                  ; Move to the next row of matrix1
           jmp outer_loop                           ; Continue outer loop

        Done: 
            ret                                     ; Stop procedure

    matrix_multiply endp

end
    