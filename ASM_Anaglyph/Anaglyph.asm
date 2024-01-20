.code
    anaglyph_alghorytm proc

        ;Parametry:
        ;rcx - wska�nik na pierwsz� prztygotowan� tablic� z zdj�cia nr 1
        ;rdx - wska�nik na drugia prztygotowan� tablic� z zdj�cia nr 2
        ;r8  - wska�nik na bitmap� wynikow� 
        ;r9 - g�ugo�� bitmap 

        mov r10, 0                          ;licznik(index)                      
        xorps xmm0, xmm0                    ;czyszczenie rejestru
        xorps xmm1, xmm1                    ;czyszczenie rejestru

        bmp_loop:                                  

            movdqa xmm0, [rcx + r10]        ;pobierane 128 bit�w z bitmapy nr 1
            movdqu xmm1, [rdx + r10]        ;pobierane 128 bit�w z bitmapy nr 2

            paddb xmm0, xmm1                ;dodanie rejestr�w

            movaps [r8 + r10], xmm0         ;przeniesienie wyniku dodawania warto�ci do bitmapy wynikowej
            add r10, 16                     ;dodanie warto�ci 16 by odpowiednio przesun�� si�  w pamieci
            cmp r10, r9                     ;sprawdzenie czy index jest taki sam jak d�ugo�� bitmap
            jl bmp_loop                     ;kontynuuj p�tle jak index nie jest taki sam jak d�ugo�� bitmap

            ret                             ;koniec procedury

    anaglyph_alghorytm endp
end