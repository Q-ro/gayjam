-> Main
=== Main ===

*[Lost memours office, my name is John, how may I help you?] 
- °Sobs° Hi?
    I... I lost my camera, this is the last place im checking, I cant go home without my camera
    Please help me...
*[Oh don't worry, can you tell me how is your camera, maybe I have it here]
    -I'ts a little pink polaroid, was my mum's, it's everything i have left °sobs°
//...
*[I think I got it, would this camera check out?]
-Yes yes yes! Thats mum's camera

*[Someone brought it not long ago, good thing you came here]
    -Thank you so much sir, you saved me
    
*[The kindness of a stranger saved your camera]
    -> St1
    =St1
    VAR a = true
        *[Is your family around?]
        ~ a =true 
            ...
            No, they won't be coming soon, I promised to keep all their photos safe, so my sis and I can remember them
            -> St2
        *[Do you need help with something else?]
        ~ a = false
            -Not really, thank again you so much sir, take care
            -> St2
    = St2
    {a:
        *[I'm so sorry, this city truly forgets no one, plase take care boy]
    -> END
  - else:
        *Have a good one boy, be safe
    -> END
}