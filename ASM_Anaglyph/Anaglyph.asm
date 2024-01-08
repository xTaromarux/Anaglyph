.code

    anaglyph_alghorytm proc

        ; Parameters:
        ; rcx - result bmp
        ; rdx - original bmp no.1
        ; r8  - original bmp no.2
        ; r9d - image size in bites

        ; Initialize variables
        mov rax, 0                                  ; rax will be used for pixel counter (BGR)
        mov r10, 0                                  ; r10 will be used for index counter

        bmp_loop:                                   ; Main loop 
            cmp rax, 2                              ; Check whether to change the bmp 
            je change_bmp                           ; Jump if true

            mov al, byte ptr [r8 + r10]             ; Store the byte from bmp no.2 in al
            mov byte ptr [rcx + r10], al            ; Move al to bmp result
            inc r10                                 ; Move to the next byte in the array
            inc rax                                 ; Move to the next byte of pixel (BGR) in the array
            dec r9d                                 ; Decrement image size = loop counter  
            jnz bmp_loop                            ; Continue loop if r9 is not 0
            ret                                     ; Stop procedure


        change_bmp:                                 ; Change to bmp no.1
            mov al, byte ptr [rdx + r10]            ; Store the byte from bmp no.1 in al
            mov byte ptr [rcx + r10], al            ; Move al to bmp result
            mov rax, 0                              ; Reset pixel counter 
            inc r10                                 ; Move to the next byte in the array
            dec r9d                                 ; Decrement image size = loop counter
            jnz bmp_loop                            ; Continue loop if r9 is not 0
            ret                                     ; Stop procedure

    anaglyph_alghorytm endp
end