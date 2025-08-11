stamina-change-display =
    { $deltasign ->
        [-1] [color=green]{NATURALFIXED($amount, 2) }[/color]
        *[1] [color=red]{NATURALFIXED($amount, 2) }[/color]
    } Stamina
# Changed code around a bit to support FixedPoint2
