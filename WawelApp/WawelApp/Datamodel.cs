using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WawelApp
{
    public class Datamodel
    {
            public App app { get; set; }
            public System system { get; set; }
            public string basePath { get; set; }
        

        public class App
        {
            public string version { get; set; }
            public string uuid { get; set; }
            public string secret { get; set; }
            public bool config_at_startup { get; set; }
            public string save_path { get; set; }
            public string operating_mode { get; set; }
            public Fiscal fiscal { get; set; }
            public Passticket passticket { get; set; }
            public Label label { get; set; }
            public Ticket ticket { get; set; }
            public PaymentTerminalEservice paymentterminaleservice { get; set; }
            public string cashbox_no { get; set; }
            public PaymentTerminal paymentterminal { get; set; }
            public Printers printers { get; set; }
            public bool is_logged { get; set; }
            public Serialports serialports { get; set; }
            public Cashbox cashbox { get; set; }
            public object[] profiles { get; set; }
        }

        public class Fiscal
        {
            public bool enabled { get; set; }
            public string port { get; set; }
            public string bound_rate { get; set; }
            public string description_length { get; set; }
            public Tax[] tax { get; set; }
            public Payment[] payments { get; set; }
            public bool opendrwr { get; set; }
            public bool confirm_payment { get; set; }
            public bool confirm_payment_always { get; set; }
            public Fiscal_Printer fiscal_printer { get; set; }
            public bool single_print { get; set; }
            public int wait_after_pdf_save { get; set; }
        }

        public class Fiscal_Printer
        {
            public string type { get; set; }
        }

        public class Tax
        {
            public string index { get; set; }
            public string value { get; set; }
        }

        public class Payment
        {
            public string index { get; set; }
            public string value { get; set; }
        }

        public class Passticket
        {
            public bool enabled { get; set; }
            public bool on_fiscal { get; set; }
            public string printer { get; set; }
            public string layout { get; set; }
            public bool single_print { get; set; }
            public int wait_after_pdf_save { get; set; }
        }

        public class Label
        {
            public bool enabled { get; set; }
            public bool on_fiscal { get; set; }
            public string printer { get; set; }
            public string layout { get; set; }
            public bool single_print { get; set; }
            public int wait_after_pdf_save { get; set; }
        }

        public class Ticket
        {
            public bool enabled { get; set; }
            public bool on_fiscal { get; set; }
            public string printer { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string layout { get; set; }
            public Margins margins { get; set; }
            public bool rasterize { get; set; }
            public int rotation { get; set; }
            public string units { get; set; }
            public bool scalecontent { get; set; }
            public bool single_print { get; set; }
            public int wait_after_pdf_save { get; set; }
        }

        public class Margins
        {
            public bool enabled { get; set; }
            public int top { get; set; }
            public int bottom { get; set; }
            public int right { get; set; }
            public int left { get; set; }
        }

        public class PaymentTerminalEservice
        {
            public bool enabled { get; set; }
            public string port { get; set; }
            public string cashier { get; set; }
        }

        public class PaymentTerminal
        {
            public bool enabled { get; set; }
            public string port { get; set; }
            public string bound_rate { get; set; }
            public string token { get; set; }
        }

        public class Printers
        {
            public string[] list { get; set; }
        }

        public class Serialports
        {
            public List[] list { get; set; }
        }

        public class List
        {
            public string comPort { get; set; }
            public string friendlyName { get; set; }
            public string portDescription { get; set; }
            public int boundRate { get; set; }
        }

        public class Cashbox
        {
            public Location_Desk[] location_desk { get; set; }
            public string location_hash { get; set; }
        }

        public class Location_Desk
        {
            public string label { get; set; }
            public string value { get; set; }
        }

        public class System
        {
            public string host { get; set; }
            public string protocol { get; set; }
        }

    }
}
