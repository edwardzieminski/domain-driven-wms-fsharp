module Domain.Office.InboundDelivery.ActivePatterns

open System
open System.Text.RegularExpressions

let (|EmptyString|_|) (input: string) =
  match input with
  | _ when String.IsNullOrWhiteSpace(input) -> Some <| EmptyString ()
  | _ -> None

let (|Matches|_|) (pattern: string) (input: string) =
  match input with
  | _ when Regex.IsMatch(input, pattern) -> Some <| Matches ()
  | _ -> None

let (|StartsWith|_|) (prefix: string) (str: string) =
  match str with
  | _ when str.StartsWith(prefix) -> Some <| StartsWith ()
  | _ -> None

let (|EndsWith|_|) (suffix: string) (str: string) =
  match str with
  | _ when str.EndsWith(suffix) -> Some <| EndsWith ()
  | _ -> None