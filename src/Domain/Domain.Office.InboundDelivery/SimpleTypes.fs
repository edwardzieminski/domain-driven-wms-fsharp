namespace Domain.Office.InboundDelivery.SimpleTypes

open Domain.Office.InboundDelivery
open Domain.Office.InboundDelivery.ActivePatterns

type LiquidCode = private LiquidCode of string
type CleaningEquipmentCode = private CleaningEquipmentCode of string
type PowerToolCode = private PowerToolCode of string
type MarketingMaterialCode = private MarketingMaterialCode of string

type ProductCode =
  | Liquid of LiquidCode
  | CleaningEquipment of CleaningEquipmentCode
  | PowerTool of PowerToolCode
  | MarketingMaterial of MarketingMaterialCode

module LiquidCode =
  [<Literal>]
  let Pattern = "^[L]\d{6}$"

  let value (LiquidCode code) = code

  let create code =
    ConstrainedType.createWithPattern LiquidCode Pattern code

module CleaningEquipmentCode =
  [<Literal>]
  let Pattern = "^[L]\d{6}$"

  let value (CleaningEquipmentCode code) = code

  let create code =
    ConstrainedType.createWithPattern CleaningEquipmentCode Pattern code

module PowerToolCode =
  [<Literal>]
  let Pattern = "^[T][L]\d{5}$"

  let value (PowerToolCode code) = code

  let create code =
    ConstrainedType.createWithPattern PowerToolCode Pattern code

module MarketingMaterialCode =
  [<Literal>]
  let Pattern = "^[X]\d{5}[A-Z]$"

  let value (MarketingMaterialCode code) = code

  let create code =
    ConstrainedType.createWithPattern MarketingMaterialCode Pattern code

module ProductCode =
  let value code =
    match code with
    | Liquid (LiquidCode lc) -> lc
    | CleaningEquipment (CleaningEquipmentCode cec) -> cec
    | PowerTool (PowerToolCode ptc) -> ptc
    | MarketingMaterial (MarketingMaterialCode mmc) -> mmc

  let create code =
    match code with
    | EmptyString -> Error "value could not be empty"
    | Matches LiquidCode.Pattern ->
      LiquidCode.create code
      |> Result.map Liquid
    | Matches CleaningEquipmentCode.Pattern ->
      CleaningEquipmentCode.create code
      |> Result.map CleaningEquipment
    | Matches PowerToolCode.Pattern ->
      PowerToolCode.create code
      |> Result.map PowerTool
    | Matches MarketingMaterialCode.Pattern ->
      MarketingMaterialCode.create code
      |> Result.map MarketingMaterial
    | _ -> Error "value has incorrect format"
