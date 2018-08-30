#include <iostream>
#include <fstream>
#include <string>
#include <fstream>
#include <streambuf>

std::string myFilePath;
std::string str;
std::string* tokens;

int main(int argc, char *argv[])
{
	if(argc > 0){
		for(int i=1; i < argc; i++){
		myFilePath += argv[i];
	}
		std::ifstream t(myFilePath);
		str = std::string((std::istreambuf_iterator<char>(t)), std::istreambuf_iterator<char>());
		str += "<EndOfFile>";
        

	}else{
		std::cout << "ERROR NO FILE TO COMPILE" << std::endl;
	}


	return 0;
}

std::string* lex(std::string file)
{

	std::string tok = "";
	char c;
	std::string str = "";
	int state = 0;
	std::string expr = "";
	int isexpr = 0;
	std::string n = "";

	while(tok != "<EndOfFile>")
	{

		tok += c;

		if(tok == " "){
			if(state == 0)
				tok = "";
			else
				tok = " ";
		}
		else if(tok == "\n"/* || tok == "<EndOfFile>"*/){
		if(expr != "" && isexpr == 1){
			tokens += "EXPR " + expr;
		}
	}

	}


}