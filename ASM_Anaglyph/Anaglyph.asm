.code
    anaglyph_alghorytm proc

        ;Parametry:
        ;rcx - wska�nik na pierwsz� prztygotowan� tablic� z zdj�cia nr 1
        ;rdx - wska�nik na drugia prztygotowan� tablic� z zdj�cia nr 2
        ;r8  - wska�nik na prztygotowan� tablic� dla rezultatu
        ;r9 - od jakiego momentu startujemy operacje
        ;r10 - do jakiego momentu wykonujemy operacje

        mov r10, [rsp + 40]                                      
        xorps xmm0, xmm0                    ;czyszczenie rejestru
        xorps xmm1, xmm1                    ;czyszczenie rejestru

        bmp_loop:                                  

            movdqu xmm0, [rcx + r9]        ;pobierane 128 bit�w z bitmapy nr 1
            movdqu xmm1, [rdx + r9]        ;pobierane 128 bit�w z bitmapy nr 2

            paddb xmm0, xmm1                ;dodanie rejestr�w

            movdqu [r8 + r9], xmm0         ;przeniesienie wyniku dodawania warto�ci do bitmapy wynikowej
            add r9, 16                     ;dodanie warto�ci 16 by odpowiednio przesun�� si�  w pamieci
            cmp r9, r10                     ;sprawdzenie czy index jest taki sam jak d�ugo�� bitmap
            jl bmp_loop                     ;kontynuuj p�tle jak index nie jest taki sam jak d�ugo�� bitmap

            ret                             ;koniec procedury

    anaglyph_alghorytm endp
end