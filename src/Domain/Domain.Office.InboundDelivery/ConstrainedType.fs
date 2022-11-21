module Domain.Office.InboundDelivery.ConstrainedType

open Domain.Office.InboundDelivery.ActivePatterns

let createWithPattern ctor pattern str =
    match str with
    | EmptyString -> Error "value could not be empty"
    | Matches pattern -> Ok(ctor str)
    | _ -> Error "value has incorrect format"