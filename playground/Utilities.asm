; namespace DebugStub

; Uses EAX: expected difference.
; Modifies: EBX
; function CheckStack {
    
    ; after a call, the stack gets pushed to, so add 4 to the expected difference
    ; eax += 4
    ; EBX = EBP
    Mov EBX, EBP
    ; EBX += EAX

    ; if EBX != ESP {
        ; stack corruption.
        ; EAX = [ESP]
        Mov EAX, DWORD [ESP]
        ; .CallerEIP = EAX
        ; SendStackCorruptionOccurred()
      ; halt:
        ; goto halt
    ; }
; }
