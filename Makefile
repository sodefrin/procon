login:
	oj login https://atcoder.jp

abc:
	mkdir abc${num}
	dotnet new console -o abc${num}/abc${num}_a
	oj dl https://atcoder.jp/contests/agc030/tasks/agc030_a -d abc${num}/abc${num}_a/test
	cp boilerplate/* abc${num}/abc${num}_a
	sed -i -e 's/NUM/${num}/g' abc${num}/abc${num}_a/Makefile
	sed -i -e 's/ID/a/g' abc${num}/abc${num}_a/Makefile 
	rm abc${num}/abc${num}_a/Makefile-e
	dotnet new console -o abc${num}/abc${num}_b
	oj dl https://atcoder.jp/contests/agc030/tasks/agc030_b -d abc${num}/abc${num}_b/test
	cp boilerplate/* abc${num}/abc${num}_b
	sed -i -e 's/NUM/${num}/g' abc${num}/abc${num}_b/Makefile
	sed -i -e 's/ID/b/g' abc${num}/abc${num}_b/Makefile
	rm abc${num}/abc${num}_b/Makefile-e
	dotnet new console -o abc${num}/abc${num}_c
	oj dl https://atcoder.jp/contests/agc030/tasks/agc030_c -d abc${num}/abc${num}_d/test
	cp boilerplate/* abc${num}/abc${num}_c
	sed -i -e 's/NUM/${num}/g' abc${num}/abc${num}_c/Makefile > abc${num}/abc${num}_c/Makefile
	sed -i -e 's/ID/c/g' abc${num}/abc${num}_c/Makefile > abc${num}/abc${num}_c/Makefile
	rm abc${num}/abc${num}_c/Makefile-e
	dotnet new console -o abc${num}/abc${num}_d
	oj dl https://atcoder.jp/contests/agc030/tasks/agc030_d -d abc${num}/abc${num}_d/test
	cp boilerplate/* abc${num}/abc${num}_d
	sed -i -e 's/NUM/${num}/g' abc${num}/abc${num}_d/Makefile > abc${num}/abc${num}_d/Makefile
	sed -i -e 's/ID/d/g' abc${num}/abc${num}_d/Makefile > abc${num}/abc${num}_d/Makefile
	rm abc${num}/abc${num}_d/Makefile-e

.PHONY: login abc
