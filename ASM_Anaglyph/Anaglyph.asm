.code
    anaglyph_alghorytm proc

        ;Parametry:
        ;rcx - wskaŸnik na pierwsz¹ prztygotowan¹ tablicê z zdjêcia nr 1
        ;rdx - wskaŸnik na drugia prztygotowan¹ tablicê z zdjêcia nr 2
        ;r8  - wskaŸnik na prztygotowan¹ tablicê dla rezultatu
        ;r9 - od jakiego momentu startujemy operacje
        ;r10 - do jakiego momentu wykonujemy operacje

        mov r10, [rsp + 40]                                      
        xorps xmm0, xmm0                    ;czyszczenie rejestru
        xorps xmm1, xmm1                    ;czyszczenie rejestru

        bmp_loop:                                  

            movdqu xmm0, [rcx + r9]        ;pobierane 128 bitów z bitmapy nr 1
            movdqu xmm1, [rdx + r9]        ;pobierane 128 bitów z bitmapy nr 2

            paddb xmm0, xmm1                ;dodanie rejestrów

            movdqu [r8 + r9], xmm0         ;przeniesienie wyniku dodawania wartoœci do bitmapy wynikowej
            add r9, 16                     ;dodanie wartoœci 16 by odpowiednio przesun¹æ siê  w pamieci
            cmp r9, r10                     ;sprawdzenie czy index jest taki sam jak d³ugoœæ bitmap
            jl bmp_loop                     ;kontynuuj pêtle jak index nie jest taki sam jak d³ugoœæ bitmap

            ret                             ;koniec procedury

    anaglyph_alghorytm endp
end