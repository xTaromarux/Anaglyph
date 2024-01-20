.code
    anaglyph_alghorytm proc

        ;Parametry:
        ;rcx - wskaŸnik na pierwsz¹ prztygotowan¹ tablicê z zdjêcia nr 1
        ;rdx - wskaŸnik na drugia prztygotowan¹ tablicê z zdjêcia nr 2
        ;r8  - wskaŸnik na bitmapê wynikow¹ 
        ;r9 - g³ugoœæ bitmap 

        mov r10, 0                          ;licznik(index)                      
        xorps xmm0, xmm0                    ;czyszczenie rejestru
        xorps xmm1, xmm1                    ;czyszczenie rejestru

        bmp_loop:                                  

            movdqa xmm0, [rcx + r10]        ;pobierane 128 bitów z bitmapy nr 1
            movdqu xmm1, [rdx + r10]        ;pobierane 128 bitów z bitmapy nr 2

            paddb xmm0, xmm1                ;dodanie rejestrów

            movaps [r8 + r10], xmm0         ;przeniesienie wyniku dodawania wartoœci do bitmapy wynikowej
            add r10, 16                     ;dodanie wartoœci 16 by odpowiednio przesun¹æ siê  w pamieci
            cmp r10, r9                     ;sprawdzenie czy index jest taki sam jak d³ugoœæ bitmap
            jl bmp_loop                     ;kontynuuj pêtle jak index nie jest taki sam jak d³ugoœæ bitmap

            ret                             ;koniec procedury

    anaglyph_alghorytm endp
end