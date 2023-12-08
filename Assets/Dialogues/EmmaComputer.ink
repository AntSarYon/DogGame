INCLUDE Globals.ink

VAR ds = 0
~ ds = RANDOM(1,3)

//Condicion con SWITCH 1
{ ds:
    - 1: ->uno
    - 2: ->dos
    - 3: ->tres
}


=== uno ===
#speaker: EMMA #audio: andreO
NUGGET, PLEASE STAY SEATED, OKAY?
-> END

=== dos ===
#speaker: EMMA #audio: andreO
I'M BUSY RIGHT NOW, WE'LL DO SOMETHING FUN LATER.
~ ladrar()
-> END

=== tres ===
#speaker: EMMA #audio: andreO
THIS IS SO BORING, HOW ABOUT WE WATCH A MOVIE LATER?
~ ladrar()
-> END
