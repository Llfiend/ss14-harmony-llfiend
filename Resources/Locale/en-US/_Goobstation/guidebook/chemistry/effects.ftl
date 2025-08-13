reagent-effect-guidebook-deal-stamina-damage =
    { $chance ->
    [1] { $deltasign ->
    [1] Deals
    *[-1] Heals
                }
    *[other]
                { $deltasign ->
    [1] deal
    *[-1] heal
                }
        } { $amount } Stamina
# Harmony, updated to function without unused Goob systems