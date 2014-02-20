#include <iostream>
#include <fstream>
#include <vector>
#include <map>
#include <string>
#include <algorithm>
using namespace std;

typedef map<string,vector<string> > ClasesDict;
ClasesDict classes;
string postPrefix ;
string entitiesFolderOutputPath ;

string PK;
vector<pair<string,string> > getForeignKeys(string entityName);

int lastn ;

string setFirstLetterUpper(string & other)
{
	string result = other;
	
	result[0] = toupper(result[0]);
	
	return result;
}
string setFirstLetterLower(string & other)
{
	string result = other;
	
	result[0] = tolower(result[0]);
	
	return result;
}

void loadEntitiesFromFile(const char * file)
{
	ifstream read(file);
	
	string line;
	// <
	getline(read,line);
	
	
	while(!read.eof())
	{
	//Entity name
		getline(read,line);
		string entityName = line;
		vector<string> attrib;
		//Attributes
		getline(read,line);
		while(line!=">")
		{
			//process attributes
			
			attrib.push_back(line);
			
			getline(read,line);
		}
		
		classes[entityName] = attrib;
		// <
		getline(read,line);
	}
	
	read.close();

}


void printClasses()
{
	
	ClasesDict::iterator it;
	
	for(it = classes.begin();it!= classes.end();it++)
	{
		cout<<it->first<<endl;
		
		for(int i=0;i<it->second.size();i++)
		{
			cout<<it->second[i]<<" ";
		}
		
		cout<<endl;
		
	}

}

void generateTableSentencesWith(string preString, string posString,string filename)
{
		ClasesDict::iterator it;
				
		
		ofstream  open(filename.c_str());
		
		for(it = classes.begin();it!= classes.end();it++)
		{
			open<<preString+it->first+posString<<endl;
		}
}

void generateORMLiteCreateTablesSentences()
{
		
		generateTableSentencesWith("db.CreateTable<",">();","orm_create_sentences.cs");

}
void generateORMLitePopulateTablesSentences()
{
		
		generateTableSentencesWith("repo.StoreRandomObjects<",">(nrows);","orm_populate_sentences.cs");

}
void generateCSharpClasses()
{

	ClasesDict::iterator it;
		string primaryKeyForSQLDB = "id";
		for(it = classes.begin();it!= classes.end();it++)
		{
			string fname = entitiesFolderOutputPath+"/"+it->first+".cs";
			cout<<fname<<endl;
			ofstream  open(fname.c_str());
			
			open<<"using System;\n\
using System.Collections.Generic;\n\
using ServiceStack.DataAnnotations;\n \
using System.Linq;\n\
using System.Text;\n\
namespace WebRole1.Api\n\
{\n\
  public  class "+it->first+"\n\
    {"<<endl;
			
			string entityName = it->first;
			for(int i=0;i<it->second.size();i++)
			{
					string typedAttrib =classes[entityName][i];
					string attrib = typedAttrib.substr(typedAttrib.find(" ")+1);
					string lcattrib = attrib;
					transform(lcattrib.begin(),lcattrib.end(),lcattrib.begin(),::tolower);
					
					if(lcattrib!= PK)
					{
						string lastTwo = lcattrib.substr(lcattrib.length()-lastn);
						
						if(lastTwo==PK)
						{
							string foreignEntity = lcattrib.substr(0,lcattrib.length()-lastn);
							foreignEntity = setFirstLetterUpper(foreignEntity);
							open<<"\t\t [References(typeof("+foreignEntity+"))]"<<endl;
						}
							
					
					}
					else
					{
						open<<"\t\t[AutoIncrement]"<<endl;
						open<<"\t\t[Alias(\""+primaryKeyForSQLDB+"\")]"<<endl;
					}
				open<<"\t\t public "<<it->second[i]<<" {get; set;}"<<endl;
			}
			
		open<<"    }\n\
}"<<endl;

			
		}

}
void generateQueryServiceMethods(ofstream & open, string entityName)
{

			ClasesDict::iterator it;
		
		
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			string lcEntity = pluralEntity ;
			
			transform(lcEntity.begin(),lcEntity.end(),lcEntity.begin(),::tolower);
			
			vector<pair<string,string> > foreignKeys = getForeignKeys(entityName);
			
			
			for(int i=0;i<foreignKeys.size();i++)
			{
				string foreignEntity = foreignKeys[i].first;
				string foreignVariable = foreignKeys[i].second;
				string entityWithUpperCase = foreignEntity;
			entityWithUpperCase[0] = toupper(entityWithUpperCase[0]);
					//GET REQUEST AND RESPONSE
			
			
				 open<<"public object Get(Get"+entityWithUpperCase+pluralEntity+" request) \n\
				{ \n\
					return new Get"+entityWithUpperCase+pluralEntity+"Response { "+pluralEntity+" = Repository.Get"+entityWithUpperCase+pluralEntity+"(request."+entityWithUpperCase+"Id)};\n \
				}"<<endl;
		
			}
		
		
			
	
			
		
}

void generateServiceMethods()
{
		ClasesDict::iterator it;
		
		
		bool POST = false;
		string serviceMethodsFile = "services_methods.cs";
		
		ofstream  open(serviceMethodsFile.c_str());
		
		for(it = classes.begin();it!= classes.end();it++)
		{
			
			
			string entityName = it->first;
			string entityPluralName = entityName+"s";
			
			//GET METHOD
			
				 open<<"public object Get("+entityPluralName+" request) \n\
				{ \n\
					return new "+entityPluralName+"Response { "+entityPluralName+" = Repository.Get<"+entityName+">()};\n \
				}"<<endl;
				
			//GET BY ID METHOD
				 open<<"public object Get(Get"+entityName+" request) \n\
				{ \n\
					return new Get"+entityName+"Response { Result"+entityName+" = Repository.Get<"+entityName+">(request.Id)};\n \
				}"<<endl;
				
				
			//POST METHOD
				string prefixEntity = postPrefix+entityName;
				
				open<< "public object Post("+prefixEntity+" request) \n\
				{\n \
					var id = Repository."+prefixEntity+"(";
					
					bool primero = true;
					for(int i=0;i<it->second.size();i++)
					{
						string typedAttrib = it->second[i];
						string attrib = typedAttrib.substr(typedAttrib.find(" ")+1);
						
						if(!primero)
							open<<",";
							
							//MAGIC STRINNNNNNNNNNGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG WARNINGGGGGGGG
						if(attrib!="Id")	
						{
							open<<"request."<<attrib;
							primero = false;
						}
						
						
					}
					
					
					open<<"); \n\
					return new "+prefixEntity+"Response { "+entityName+"Id = id };\n \
				} "<<endl;
				
			// query GET METHOD
			 generateQueryServiceMethods(open,entityName);

			
		}

}

void generateQueryRequestResponseClasses(ofstream & open, string entityName)
{

			ClasesDict::iterator it;
		
		
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			string lcEntity = pluralEntity ;
			
			transform(lcEntity.begin(),lcEntity.end(),lcEntity.begin(),::tolower);
			
			vector<pair<string,string> > foreignKeys = getForeignKeys(entityName);
			
			
			for(int i=0;i<foreignKeys.size();i++)
			{
				string foreignEntity = foreignKeys[i].first;
				string foreignVariable = foreignKeys[i].second;
				string entityWithUpperCase = foreignEntity;
			entityWithUpperCase[0] = toupper(entityWithUpperCase[0]);
					//GET REQUEST AND RESPONSE
			
			open<<"\t[Route(\"/"+foreignEntity+"_"+lcEntity+"/{"+entityWithUpperCase+"Id}\",\"GET\")] \n \
	public class Get"+entityWithUpperCase+pluralEntity+ "\n \
	{";
			open<< "\t\t public long "+entityWithUpperCase+"Id { get; set; }"<<endl;
			open<<"\n \t}"<<endl;
			
			open<<"public class Get"+entityWithUpperCase+pluralEntity+"Response \n \
{ \n \
		public IEnumerable<"+entityName+"> "+pluralEntity+" { get; set; } \n \
} "<<endl;
			}
		
		
			
	
			
		
}

void generateServiceRequestResponseClasses()
{
		ClasesDict::iterator it;
		
		string serviceFile = "services_req_res.cs";
		
		ofstream  open(serviceFile.c_str());
		
		for(it = classes.begin();it!= classes.end();it++)
		{
			string entityName = it->first;
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			string lcEntity = pluralEntity ;
			
			transform(lcEntity.begin(),lcEntity.end(),lcEntity.begin(),::tolower);
			
			//POST REQUEST AND RESPONSE
			open<<"\t[Route(\"/"+lcEntity+"\",\"POST\")] \n \
	public class "+prefixEntity+ "\n \
	{ \n";
			
			for(int i=0;i<it->second.size();i++)
			{
					string typedAttrib = it->second[i];
					string attrib = typedAttrib.substr(typedAttrib.find(" ")+1);
					
					//The ID is autoincrement, so no need to pass it
					if(attrib!="Id")
						open<<"\t\t public "<<it->second[i]<<" {get; set;}"<<endl;
			}
			
			open<<"\n \t}"<<endl;
			
			open<<"public class "+prefixEntity+"Response \n \
{ \n \
		public long "+entityName+"Id { get; set; } \n \
} "<<endl;

			
			
			
			//GET REQUEST AND RESPONSE
			
			open<<"\t[Route(\"/"+lcEntity+"\",\"GET\")] \n \
	public class "+pluralEntity+ "\n \
	{";
			
			open<<"\n \t}"<<endl;
			
			open<<"public class "+pluralEntity+"Response \n \
{ \n \
		public IEnumerable<"+entityName+"> "+pluralEntity+" { get; set; } \n \
} "<<endl;
			
			//GET BY ID REQUEST AND RESPONSE
			
			open<<"\t[Route(\"/"+lcEntity+"/{Id}\",\"GET\")] \n \
	public class Get"+entityName+ "\n \
	{ \n";
			open<<" public long Id { get; set; } \n \t}"<<endl;
			
			open<<"public class Get"+entityName+"Response \n \
{ \n \
		public "+entityName+" Result"+entityName+" { get; set; } \n \
} "<<endl;


		generateQueryRequestResponseClasses(open,entityName);

			
		}
}


void listFieldsAsParameters(ofstream &open ,string entityName)
{
	
	
		bool primero = true;
		for(int i=0;i<classes[entityName].size();i++)
			{
					string typedAttrib =classes[entityName][i];
					string attrib = typedAttrib.substr(typedAttrib.find(" ")+1);
					
					transform(attrib.begin(),attrib.end(),attrib.begin(),::tolower);
					string type = typedAttrib.substr(0,typedAttrib.find(" "));
					
				
					if(!primero)
							open<<", ";		
					if(attrib!=PK)
					{																
						open<<type<<" "<<attrib;					
						primero = false;
					}
			}

}

void generateQueryInterfaceRepositoryMethods(ofstream & open, string entityName)
{
	ClasesDict::iterator it;
		
		
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			string lcEntity = pluralEntity ;
			
			transform(lcEntity.begin(),lcEntity.end(),lcEntity.begin(),::tolower);
			
			vector<pair<string,string> > foreignKeys = getForeignKeys(entityName);
			
			
			for(int i=0;i<foreignKeys.size();i++)
			{
				string foreignEntity = foreignKeys[i].first;
				string foreignVariable = foreignKeys[i].second;
				string entityWithUpperCase = foreignEntity;
			entityWithUpperCase[0] = toupper(entityWithUpperCase[0]);
			
				open<<"IEnumerable<"+entityName+"> Get"+entityWithUpperCase+pluralEntity+"(long "+foreignEntity+"id);"<<endl;
					
			}

}
void generateInterfaceRepositoryMethods()
{

	ClasesDict::iterator it;
		
	string serviceFile = "repo_interface_methods.cs";
		
	ofstream  open(serviceFile.c_str());
	
		for(it = classes.begin();it!= classes.end();it++)
		{
	
			string entityName = it->first;
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			open<<"long "+prefixEntity+"(";
			listFieldsAsParameters(open,entityName);
			open<<" );"<<endl;
			//cout<<"IEnumerable<"+entityName+"> Get"+pluralEntity+"();"<<endl;
			//open<< entityName +" Get"+pluralEntity+"(long entityId);"<<endl;
			
			generateQueryInterfaceRepositoryMethods(open,entityName);
			
		}


}

void listInitialization(ofstream &open ,string entityName)
{
		
		bool primero = true;
		for(int i=0;i<classes[entityName].size();i++)
			{
					string typedAttrib =classes[entityName][i];
					string attrib = typedAttrib.substr(typedAttrib.find(" ")+1);
					string lcattrib = attrib;
					transform(lcattrib.begin(),lcattrib.end(),lcattrib.begin(),::tolower);
					
					
				
					if(!primero)
							open<<", ";		
					if(lcattrib!=PK)
					{																
						open<<attrib<<" = "<<lcattrib;					
						primero = false;
					}
			}
}

//get Foreign Entity lowercase name  and the variable name which contains the id value
vector<pair<string,string> > getForeignKeys(string entityName)
{
		vector<pair<string,string> > foreignKeys;
		
		
		for(int i=0;i<classes[entityName].size();i++)
		{
					string typedAttrib =classes[entityName][i];
					string attrib = typedAttrib.substr(typedAttrib.find(" ")+1);
					string lcattrib = attrib;
					transform(lcattrib.begin(),lcattrib.end(),lcattrib.begin(),::tolower);
					
					if(lcattrib!= PK)
					{
						string lastTwo = lcattrib.substr(lcattrib.length()-lastn);
					
						if(lastTwo==PK)
						{
							string foreingEntity = lcattrib.substr(0,lcattrib.length()-lastn);
							foreignKeys.push_back(make_pair(foreingEntity,lcattrib));
						}
							
					
					}
		}
		
		return foreignKeys;
		
}

void writeForeingKeysRestriction(ofstream & open,vector<pair<string,string> > & foreignKeys)
{

	open<<"\t if (";
	for(int i=0;i<foreignKeys.size();i++)
	{
			if(i!=0)
				open<<" && ";
			open<<"isValidId(\""+foreignKeys[i].first+"\","+foreignKeys[i].second+")";
	}
	
	open<<") \n \t { \n";
	
}

void listAddToSetMethods(ofstream & open,vector<pair<string,string> > & foreignKeys,string entityName)
{

	for(int i=0;i < foreignKeys.size();i++)
	{
			string foreignEntity = foreignKeys[i].first;
			string foreignVariable = foreignKeys[i].second;
			
			string entityWithUpperCase = foreignEntity;
			entityWithUpperCase[0] = toupper(entityWithUpperCase[0]);
			
			open<<"\t\t\t\t redisClient.AddItemToSet("+entityWithUpperCase+entityName+"Index."+entityName+"s("+foreignVariable+"), entidad.Id.ToString());"<<endl;
	}
}

void generateQueryOrmLiteRepositoryImplementation(ofstream & open, string entityName)
{
ClasesDict::iterator it;
		
		
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			string lcEntity = pluralEntity ;
			
			transform(lcEntity.begin(),lcEntity.end(),lcEntity.begin(),::tolower);
			
			vector<pair<string,string> > foreignKeys = getForeignKeys(entityName);
			
			
			for(int i=0;i<foreignKeys.size();i++)
			{
				string foreignEntity = foreignKeys[i].first;
				string foreignVariable = foreignKeys[i].second;
				string entityWithUpperCase = foreignEntity;
			entityWithUpperCase[0] = toupper(entityWithUpperCase[0]);
			
			open<<"public IEnumerable<"+entityName+"> Get"+entityWithUpperCase+pluralEntity+"(long "+foreignEntity+"id) \n \
        { \n \
            using (IDbConnection db = DbFactory.OpenDbConnection()) \n \
            { \n \				
					return db.Select<"+entityName+">(\""+entityWithUpperCase+"Id = {0}\", "+foreignEntity+"id); \n \					
            } \n \
        } \n "<<endl;
					
			}
}
void generateQueryRedisRepositoryImplementation(ofstream & open, string entityName)
{
	ClasesDict::iterator it;
		
		
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			string lcEntity = pluralEntity ;
			
			transform(lcEntity.begin(),lcEntity.end(),lcEntity.begin(),::tolower);
			
			vector<pair<string,string> > foreignKeys = getForeignKeys(entityName);
			
			
			for(int i=0;i<foreignKeys.size();i++)
			{
				string foreignEntity = foreignKeys[i].first;
				string foreignVariable = foreignKeys[i].second;
				string entityWithUpperCase = foreignEntity;
			entityWithUpperCase[0] = toupper(entityWithUpperCase[0]);
			
			open<<"public IEnumerable<"+entityName+"> Get"+entityWithUpperCase+pluralEntity+"(long "+foreignEntity+"id) \n \
        { \n \
            using (var redisClient = RedisManager.GetClient()) \n \
            { \n \
                var ids"+pluralEntity +"= redisClient.GetAllItemsFromSet("+entityWithUpperCase+entityName+"Index."+pluralEntity+"("+foreignEntity+"id)); \n \
              return redisClient.As<"+entityName+">().GetByIds(ids"+pluralEntity+"); \n \
            } \n \
        } \n "<<endl;
					
			}

}

void generateOrmLiteRepositoryImplementation()
{
		ClasesDict::iterator it;
		
		string serviceFile = "orm_imp.cs";
		
		ofstream  open(serviceFile.c_str());
		
		for(it = classes.begin();it!= classes.end();it++)
		{
			string entityName = it->first;
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			// Add Method Implementation
			open<<"public long "+prefixEntity+"(";
			listFieldsAsParameters(open,entityName);
			open<<" ) \n \
{ \n ";
			
			open<<"\t\t\t using (IDbConnection db = DbFactory.OpenDbConnection()) \n\
            { \n \
				try \n\
                { \n\
					db.Insert(new "+entityName+"{";
					listInitialization(open,entityName);
					open<<"}); "<<endl;
						
                open<<"\t\t\t\t\t return db.GetLastInsertId(); \n \
				} \n\
				 catch (System.Data.SqlClient.SqlException e) \n \
                { \n \
                    return -1; \n \
				} \n \			
			} "<<endl;
			
			
		open<<"} "<<endl;

            //Get Method Implementation
     /*   
		open<<"public IEnumerable<"+entityName+"> Get"+pluralEntity+"() \n \
        { \n \
            using (IDbConnection db = DbFactory.OpenDbConnection()) \n \
            { \n \
                return db.Select<"+entityName+">(); \n \
            } \n \
        } \n "<<endl;

		//Get by ID Method Implementation
		
		open<<"public "+entityName+" Get"+pluralEntity+"(long entityId) \n \
        { \n \
            using (IDbConnection db = DbFactory.OpenDbConnection()) \n \
            { \n \
				try \n \
                { \n \
					return db.Single<"+entityName+">(\"Id = {0}\",entityId); \n \
				} \n \
				 catch(System.ArgumentNullException) \n \
                { \n \
                    return new "+entityName+"(); \n \
                } \n \
            } \n \
        } \n "<<endl;
	*/
		
		//Query method Implementation
		generateQueryOrmLiteRepositoryImplementation(open,entityName);
		
		}


}
void generateRedisRepositoryImplementation()
{

		ClasesDict::iterator it;
		
		string serviceFile = "redis_imp.cs";
		
		ofstream  open(serviceFile.c_str());
		
		for(it = classes.begin();it!= classes.end();it++)
		{
			string entityName = it->first;
			
			string prefixEntity = postPrefix+entityName;
			string pluralEntity = entityName+"s";
			
			// Add Method Implementation
			open<<"public long "+prefixEntity+"(";
			listFieldsAsParameters(open,entityName);
			open<<" ) \n \
{ \n ";
			vector<pair<string,string> > foreignKeys = getForeignKeys(entityName);
			bool containsforeignKeys = !foreignKeys.empty();
			if(containsforeignKeys)
			{
				writeForeingKeysRestriction(open,foreignKeys);
				cout<<entityName<<" contains"<<endl;
			}
			open<<"\t\t\t using (var redisClient = RedisManager.GetClient()) \n\
            { \n \
                var redis"+pluralEntity +"= redisClient.As<"+entityName+">(); \n \
				var entidad = new "+entityName+ "{ ";
				listInitialization(open,entityName);
				open<<", Id = redis"+pluralEntity +".GetNextSequence()";
				open<<"}; \n \
                redis"+pluralEntity +".Store(entidad);"<<endl;
				
				//Add index to Redis Set
				if(containsforeignKeys)
				{
					listAddToSetMethods(open,foreignKeys,entityName);
				}
                open<<"\t\t\t\t return entidad.Id; \n \
			} "<<endl;
			
			if(containsforeignKeys)
			{
						open<<"\t } \n \ 
			else \n \ 
			{ \n \
						return -1; \n\
			} "<<endl;
			}
		open<<"} "<<endl;

            //Get Method Implementation
    /*    
		open<<"public IEnumerable<"+entityName+"> Get"+pluralEntity+"() \n \
        { \n \
            using (var redisClient = RedisManager.GetClient()) \n \
            { \n \
                var redis"+pluralEntity +"= redisClient.As<"+entityName+">(); \n \
               return redis"+pluralEntity +".GetAll(); \n \
            } \n \
        } \n "<<endl;

		//Get by ID Method Implementation
		
		open<<"public "+entityName+" Get"+pluralEntity+"(long entityId) \n \
        { \n \
            using (var redisClient = RedisManager.GetClient()) \n \
            { \n \
                var redis"+pluralEntity +"= redisClient.As<"+entityName+">(); \n \
               return redis"+pluralEntity +".GetById(entityId); \n \
            } \n \
        } \n "<<endl;
	*/
		
		//Query method Implementation
		generateQueryRedisRepositoryImplementation(open,entityName);
		}
}


void generateRedisSetsClasses()
{
		ClasesDict::iterator it;
		
		string serviceFile = "redis_sets_classes.cs";
		
		ofstream  open(serviceFile.c_str());
		
		for(it = classes.begin();it!= classes.end();it++)
		{
			string entityName = it->first;
			string pluralEntity = entityName+"s";
			string lowerCEntity = setFirstLetterLower(entityName);
			vector<pair<string,string> > foreignKeys = getForeignKeys(entityName);
			bool containsforeignKeys = !foreignKeys.empty();
			if(containsforeignKeys)
			{
				for(int i=0;i<foreignKeys.size();i++)
				{
						string lcName = foreignKeys[i].first;
						string foreignName = setFirstLetterUpper(lcName);
						
						
						open<<"  static class "+foreignName+entityName+"Index \n\
        { \n \
			internal static string "+pluralEntity+"(long "+lcName+"id)\n \
            {\n \
                return \"urn:"+lcName+">"+lowerCEntity+":\" + "+lcName+"id;\n\
            }\n \
        }"<<endl;
				}
			
			}
		}

}




int main()
{
	postPrefix = "Add";
	entitiesFolderOutputPath = "entities" ;
	//CHECK WARNING
	PK = "id";
	//Last 2 chars to check if is foreing key
	lastn = 2 ;
	loadEntitiesFromFile("entities.txt");
	//printClasses();
	generateCSharpClasses();
	generateServiceMethods();
	generateServiceRequestResponseClasses();
	generateInterfaceRepositoryMethods();
	generateRedisRepositoryImplementation();
	generateRedisSetsClasses();
	generateORMLiteCreateTablesSentences();
	generateOrmLiteRepositoryImplementation();
	generateORMLitePopulateTablesSentences();
	
	return 0;
}
