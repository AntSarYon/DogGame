INCLUDE Globals.ink

VAR dk = 0
~ dk = RANDOM(1,3)

//Condicion con SWITCH 1
{ dk:
    - 1: ->uno
    - 2: ->dos
    - 3: ->tres
}


=== uno ===
~ ladrar()
#speaker: EMMA #audio: andreO
BE PATIENT NUGGET! THE FOOD IS ALMOST READY
~ EnableCalendar()
-> END

=== dos ===
~ ladrar()
#speaker: EMMA #audio: andreO
SIT DOWN PRECIOUS, I WILL SERVE YOU YOUR MEAL IN A LITTLE WHILE
~ EnableCalendar()
-> END

=== tres ===
~ ladrar()
#speaker: EMMA #audio: andreO
ALL RIGHT ALL RIGHT, I'LL HURRY
~ EnableCalendar()
-> END
