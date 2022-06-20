filename resp temp;
proc http
  url='https://localhost:44300/api/GetListOfActiveTask'
  method="get"
  out=resp;
run;
libname rss json fileref=resp;
Libname stud Base "C:\Users\Seqiiu\Source\Repos\Seqiiu\ToDoList\WebApi\wwwroot\SAS\";
data stud.lista;
set rss.root;
run;



ods _all_ close;
ods listing gpath = "C:\Users\Seqiiu\Source\Repos\Seqiiu\ToDoList\WebApi\wwwroot\SAS\";
ods graphics on /reset imagefmt = png reset imagename = "wykres";

proc sgplot data =Stud.Lista;
scatter x=taskId y=statusId;
run;

ods graphics off;
ods listing ;
