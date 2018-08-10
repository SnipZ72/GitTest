using System;
using System.Collections.Generic;

public class Test
{

	static List<string> tokens = new List<string>();

	static void Main(string[] args)
	{
		List<string> t = new List<string>();
		string fileContents = "";
		if(args.Length > 0){
			fileContents = GetFileText(args[0].ToString());
			fileContents += "<EndOfFile>";
			t =Lex(fileContents);
			Parse(t);
		}

	}


	static void Parse(List<string> tok)
	{
		int i=0;
		while(i < tok.Count)
		{
			if(tok[i] + " " + tok[i+1].Substring(0,6) == "PRINT STRING"){
				Console.WriteLine(tok[i+1].Substring(8,tok[i+1].Length - 8));
			}
			i+= 2;
		}
	}

	static List<string> Lex(string file)
	{
		string tok = "";
		string str = "";
		int state = 0;
		string expr = "";
		int isexpr = 0;
		string n = "";
		foreach(char c in file)
		{
			tok += c;
			if(tok == " ")
			{
				if(state == 0)
					tok = "";
					else 
					{
						tok = " ";
					}
			}
			else if(tok == Environment.NewLine || tok == "<EndOfFile>"){
				if(expr != "" && isexpr == 1){
					Console.WriteLine(expr + " EXPR");
					expr = "";
					isexpr = 0;
				}else if (expr != "" && isexpr == 0){
					Console.WriteLine(expr + " NUM");
					expr = "";
				}
				tok = "";
			}else if (tok == "0" || tok == "1" || tok == "2" || tok == "3" || tok == "4" || tok == "5" || tok == "6" || tok == "7" || tok == "8" || tok == "9"){
				expr += tok;
				tok = "";
			}else if (tok == "+"){
				isexpr = 1;
				expr += tok;
				tok = "";
			}
			else if (tok == "print")
			{
				tokens.Add("PRINT");
				tok = "";
			}
			else if (tok == "\""){
				if(state == 0){
					state = 1;
				}
				else if(state == 1){
					tokens.Add("STRING: " + str + "\"");
					str = "";
					state = 0;
					tok = "";
				}
			}
			else if (state == 1){
				str += tok;
				tok = "";
				
			}
		}//End of Forloop
		return tokens;
	}

	static string GetFileText(string arg)
	{

		return System.IO.File.ReadAllText(arg);

	}

}