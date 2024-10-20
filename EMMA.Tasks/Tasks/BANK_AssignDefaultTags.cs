using EMMA_BE.Generated;
using System.Text.RegularExpressions;

namespace EMMA.Tasks {
    internal partial class BANK_AssignDefaultTags {
        private const string IMPORT_PATTERN = "+000,000.00;-000,000.00";

        public override void Run() {
            BANK_STATEMENT_Query _BANK_STATEMENT_Query = new(configuration);
            List<BANK_STATEMENT_Record> _BANK_STATEMENT_Record_List = _BANK_STATEMENT_Query.SelectAll();

            //List<Record> reason_List = _BANK_STATEMENT_Record_List.Select(x => new Record(x, x.REASON)).ToList();
            //List<Record> tag2_List = _BANK_STATEMENT_Record_List.Select(x => new Record(x, x.TAG2)).ToList();
            //List<Record> tag3_List = _BANK_STATEMENT_Record_List.Select(x => new Record(x, x.TAG3)).ToList();
            //List<Record> tag4_List = _BANK_STATEMENT_Record_List.Select(x => new Record(x, x.TAG4)).ToList();

            //#region Replace
            //foreach (Record reason in reason_List) {
            //    reason.GroupedValue = reason.OriginalValue switch {
            //        "PRELIEVO BANCOMAT" or "PRELIEVO" => "ATM withdrawal",
            //        "PRELIEVO O PAGAMENTO CON CARTA EUROPAY" => "ATM withdrawal or Card payment",
            //        "BONIFICO" or "BONIFICO - SEPA" or "Bonifico - SEPA istantaneo" or "Bonifico" or "BONIFICO PROGRAMMATO" or "BONIFICO SEPA" or "Bonifico istantaneo" => "Bank transfer",
            //        "ADDEBITO SDD" => "Debit",
            //        "Addebiti Diretti" => "Direct debit",
            //        "COMMISSIONI SEND MONEY" => "Fees on money send",
            //        "COMMISSIONI SU PAGAMENTO BOLLETTINO" => "Fees on payment slip",
            //        "SEND MONEY PAYPAL" => "PayPal send money",
            //        "PAGAMENTO POS" or "PAGAMENTO - POS" => "POS Payment",
            //        "BOLLETTINI POSTALI" => "Postal payment slip",
            //        "ACCREDITO EMOLUMENTI" => "Salary",
            //        "IMPOSTA DI BOLLO" => "Stamp duty",
            //        "PAGAMENTO UTENZA TELEFONICA" => "Telephone bill payment.",
            //        "PAGAMENTO UTENZE" => "Utility payment",
            //        _ => throw new Exception($"Unmanaged Reason value '{reason.OriginalValue}'")
            //    };
            //}

            //foreach (Record tag2 in tag2_List) {
            //    tag2.GroupedValue = tag2.OriginalValue switch {
            //        "MYFREEDOM ONE PROMO YOUNG-001/01854908/05" or "001/01854908/05" => "Bank Account 001/01854908/05",
            //        _ => throw new Exception($"Unmanaged Tag2 value '{tag2.OriginalValue}'")
            //    };
            //}

            //foreach (Record tag3 in tag3_List) {
            //    tag3.GroupedValue = tag3.OriginalValue switch {
            //        "AMAZON EU S.A R.L. AMAZON EU S.A R.L-OL0P7(POA6ARDT34R2:7G" or "AMAZON PAYMENTS EUROPE S.C.A. AMAZON-OL0P7(POA6ARDT34R2:7G" or "AMAZON EU S.A R.L. AMAZON EU S.A R.L." or "AMAZON PAYMENTS EUROPE S.C.A. JM4J9E" or "AMAZON PAYMENTS EUROPE S.C.A. RA7YOA" => "Amazon",
            //        "AMERICAN EXPRESS ITALIA SRL-E2022110065691827" => "American Express",
            //        "Carte" or "Mediolanum Card-04363561" or "CARTA EUROPAY/BMAT-04363561" => "Card",
            //        "FASTWEB SPA-3F3811A11465506" => "Fastweb",
            //        "FCE BANK PLC-BRIT01600400150521200" or "FORD CREDIT ITALIA SPA-BRIT01600400020150700" or "FORD CREDIT ITALIA SPA-BRIT01600400150521200" or "FORD CREDIT ITALIA SPA-BRIT01600400170675000" or "IT15001000000458851100" or "A FAV. GRUPPO FERRARI SPA" or "GRUPPO FERRARI S P A" => "Ford Credit",
            //        "PAYPAL EUROPE S.A.R.L. ET CIE S.C.A-5NS2224TTXP6G" or "PAYPAL (EUROPE) S.A.R.L. ET CIE., S.C.A.-5NS2224TTXP6G" or "PAYPAL EUROPE SARL ET CIE SCA" or "PAYPAL EUROPE S.A.R.L. ET CIE S.C.A" or "LU96ZZZ000000000000000" or "UBIGLE S.R.L.-5NS2224TTXP6G" => "PayPal",
            //        "SKY-287B140000000022086845" => "Sky",
            //        "TELECOM ITALIA SPA-052100873999202201111" or "TELECOM ITALIA SPA-052100873999202402241" => "Telecom",
            //        "THE SPACE CINEMA 1 SPA" => "TheSpace cinema",
            //        "TRADE REPUBLIC BANK GMBH" => "Trade Republic",
            //        "" => "Undefined",
            //        "BONIFICO - SEPA ISTANTANEO MAMMA" => "Bank transfer",
            //        "LUCIANO ALLEGRI" or "A FAV. PAPA" => "Bank transfer - Allegri Luciano",
            //        "ALLEGRI SIMONE" => "Bank transfer - Allegri Simone",
            //        "DENTI KATIA" or "BONIFICO - SEPA ISTANTANEO MAMMA COOR.BENEF.: IT94 Q030 6234 2100 0000 1143 753" => "Bank transfer - Denti Katia",
            //        "A FAV. GAIA FONTANA" => "Bank transfer - Fontana Gaia",
            //        "A FAV. IMMOBILIARE FOLGARIDA" => "Bank transfer - Immobiliare Folgarida",
            //        "A FAV. FRANCESCO RIGOLLI" => "Bank transfer - Rigolli Francesco",
            //        "SAN SECONDO 1917 ASD" => "Bank transfer - SanSecondo1917",
            //        "SOLITO FRANCESCO" => "Bank transfer - Solito Francesco",
            //        _ => throw new Exception($"Unmanaged Tag3 value '{tag3.OriginalValue}'")
            //    };
            //}

            //foreach (Record tag4 in tag4_List) {
            //    tag4.GroupedValue = tag4.OriginalValue switch {
            //        "Prelievi - Pagamenti" => "ATM withdrawal - Payment",
            //        "Addebiti diretti" => "Direct debit",
            //        "Bonifici" => "Bank transfer",
            //        "Stipendi - Pensioni" => "Salary",
            //        "Bollettini" => "Payment slip",
            //        "Pagamenti" => "Payment",
            //        "Spese di gestione" => "Management fees",
            //        "PayPal" => "Paypal",
            //        _ => throw new Exception($"Unmanaged Tag4 value '{tag4.OriginalValue}'")
            //    };
            //}
            //#endregion

            //#region Print
            //Print(reason_List, "REASON");
            //Print(tag2_List, "TAG2");
            //Print(tag3_List, "TAG3");
            //Print(tag4_List, "TAG4");
            //#endregion

            string[] description_List = [.. _BANK_STATEMENT_Record_List.Select(x => x.DESCRIPTION).Order()];
            for (int i = 0; i < description_List.Length; i++) {
                bool edited;
                do {
                    edited = false;

                    Dictionary<string, string> pattern_Dict = [];
                    //pattern_Dict.Add("", "");

                    pattern_Dict.Add("DIRECT_DEBIT", @"^ADDEBITO DIRETTO CORE (FRST|RCUR) PRG.CAR.: \d{15} ");

                    pattern_Dict.Add("TELECOM", @"052100873999\d{9} TELECOMITALIA SPA - - UNCRITMM XXX IT390030000000488410010$");
                    pattern_Dict.Add("PAYPAL", @"5NS2224TTXP6G PAYPAL (\(EUROPE\)|EUROPE) (S\.A R\.L\.|S\.A\.R\.L\.) ET (CIE,|CIE\.,|CIE) (S\.C\.A \.|S\.C\. A\.|S\.C\.A) - \d{13}( PAYPAL|\/PAYPAL|) - (DEUTDEFFXXX|PPLXLUL2) LU96ZZZ0000000000000000058$");
                    pattern_Dict.Add("FORD_CREDIT", @"BRIT01600400150521200 (FCE BANK PLC|FORD CREDIT ITALIA SPA) - 00150(| )5212 - BCI(| )TITMMXXX (IT150010000004588511008|IT340010000015888421003$)$");
                    pattern_Dict.Add("FORD_CREDIT_2", @"(BRIT01600400150521200|BRIT01600400020150700|BRIT01600400170675000) FORD CREDIT ITALIA S.P.A. - NU MERO DI CONTRATTO : (016004001505212|016004001706750|016004000201507) SCADENZA RATA \d{2} /\d{2}/\d{4}(|\/ULTD\/IT) - CHASIE4LXXX IT340010000015888421003$");
                    pattern_Dict.Add("AMERICAN_EXPRESS", @"E2022110065691827 AMERICAN EXPRESS ITALIA SRL - 1100 2 - CIPBITMM(|XXX) IT07AEX0000014445281000");

                    //string BankTransferMom = @"^BONIFICO - SEPA ISTANTANEO MAMMA BONIFICO DISPOSTO IN: INTERNET COOR\.BENEF\.: IT94 Q030 6234 2100 0000 1143 753 DATA ORDINE: \d{2}\/\d{2}\/\d{2} DATA ACCREDITO: \d{2}\/\d{2}\/\d{2} CRO: [A-Z0-9]{32} CONTO BENEFICIARIO \.\.\.:$";
                    //string BankTransferMom2 = @"^BONIFICO - SEPA ISTANTANEO MAMMA COOR\.BENEF\.: IT94 Q030 6234 2100 0000 1143 753 DATA ORDINE: \d{2}\/\d{2}\/\d{2} DATA ACCREDITO: \d{2}\/\d{2}\/\d{2} CRO: [A-Z0-9]{32} CONTO BENEFICIARIO \.\.\.: 01\/001\/01143753 MAMMA A 00000 B$";
                    //string BankTransferFromPaypal = @"^BONIFICO A VS\. FAVORE PAYPAL EUROPE (S\.A\.R\.L\.|SARL) ET CIE (S\.C\.A|SCA) NOTE: [A-Z0-9]{16}( |\/)PAYPAL DATA REGOLAMENTO: \d{2}\/\d{2}\/\d{2} COD\.ID\.ORD: (LU89 7510 0013 5104 200E|FR76 3000 4021 1800 0101 3711 792) BANCA ORDINANTE: (PPLXLUL2|BNPAFRPP) CRO: ([A-Z0-9]{16} ID\.OPERAZIONE: [A-Z0-9]{16}|[A-Z0-9]{34})$";

                    foreach (KeyValuePair<string, string> pattern in pattern_Dict)
                        Replace(pattern, ref description_List[i], ref edited);
                } while (edited);
            }
            Dictionary<string, int> remainingStrings = description_List.Where(x => !x.StartsWith("%%") || !x.EndsWith("%%")).Order().GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }

        private static void Replace(KeyValuePair<string, string> pattern, ref string description, ref bool edited) {
            edited = edited || Regex.IsMatch(description, pattern.Value);
            description = Regex.Replace(description, pattern.Value, $"%%{pattern.Key}%%");
        }

        private class Record(BANK_STATEMENT_Record record, string value) {
            public string GroupedValue { get; set; } = string.Empty;
            public string OriginalValue { get; set; } = value.Trim();
            public decimal? Income { get; set; } = record.INCOME;
            public decimal? Outcome { get; set; } = record.OUTCOME;
            public DateTime OperationDate { get; set; } = record.OPERATION_DATE;
        }

        private class GroupByKey(string originalValue) {
            public string OriginalValue { get; set; } = originalValue;
            public string GroupedValue { get; set; } = string.Empty;
        }

        private static void Print(List<Record> recordList, string field) {
            logger.Info($"=== {field} ".PadRight(100, '='));
            int maxLengthGroupedValue = recordList.Max(x => x.GroupedValue.Length);
            int maxLengthOriginalValue = recordList.Max(x => x.OriginalValue.Length);
            int maxLength = Math.Max(maxLengthGroupedValue, maxLengthOriginalValue);
            foreach (KeyValuePair<string, List<Record>> group in recordList.GroupBy(x => x.GroupedValue).ToDictionary(x => x.Key, x => x.ToList())) {
                decimal totalIncome = group.Value.Sum(x => x.Income ?? 0);
                decimal totalOutcome = group.Value.Sum(x => x.Outcome ?? 0);
                logger.Info($"    {group.Key.PadRight(maxLength + 4, '_')}: {totalIncome.ToString(IMPORT_PATTERN)} / {totalOutcome.ToString(IMPORT_PATTERN)} / {(totalIncome - totalOutcome).ToString(IMPORT_PATTERN)} / {group.Value.Min(x => x.OperationDate.ToString("yyyy-MM-dd"))} / {group.Value.Max(x => x.OperationDate.ToString("yyyy-MM-dd"))}");
                foreach (KeyValuePair<string, List<Record>> group2 in group.Value.GroupBy(x => x.OriginalValue).OrderByDescending(x => x.Max(y => y.OperationDate)).ToDictionary(x => x.Key, x => x.ToList())) {
                    decimal totalIncome2 = group2.Value.Sum(x => x.Income ?? 0);
                    decimal totalOutcome2 = group2.Value.Sum(x => x.Outcome ?? 0);
                    logger.Info($"        {group2.Key.PadRight(maxLength, '_')}: {totalIncome2.ToString(IMPORT_PATTERN)} / {totalOutcome2.ToString(IMPORT_PATTERN)} / {(totalIncome2 - totalOutcome2).ToString(IMPORT_PATTERN)} / {group2.Value.Min(x => x.OperationDate.ToString("yyyy-MM-dd"))} / {group2.Value.Max(x => x.OperationDate.ToString("yyyy-MM-dd"))}");
                }
                logger.Info(string.Empty);
            }
        }
    }
}
