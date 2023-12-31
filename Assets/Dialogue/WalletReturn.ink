-> main
=== main ===

- Hi! excuse me, i dropped my wallet somewhere in the station, someone may have found it, could it be here? # speaker: NPC
    *[Good morning, i'm sorry, i need to verify that the wallet is actually yours.]
        ->ask
        = ask
        *[can you tell me your name?]

- Pedro Martinez, is a black wallet, it has my name engraved on the back.
//...

    *[All right i have it right here, someone brought it a few minutes ago]
    -Thank you so much, i can't continue my trip without it
    -> convo
= convo
    *[You seem in a hurry, mind if i ask where you're going]
    -As far as i can, Mr. 
    My family left already, have no business in this dying city anymore
    *[Thats...]
    ->2d
    =2d
        *[I hope everything turns fine for you and your family]

->END