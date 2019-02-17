login:
	oj login https://atcoder.jp

abc:
	mkdir abc${num}
	dotnet new console -o abc${num}/a
	oj dl https://atcoder.jp/contests/abc${num}/tasks/abc${num}_a -d abc${num}/a/test
	cp boilerplate/* abc${num}/a
	sed -i -e 's/NUM/${num}/g' abc${num}/a/Makefile
	sed -i -e 's/ID/a/g' abc${num}/a/Makefile 
	rm abc${num}/a/Makefile-e
	dotnet new console -o abc${num}/b
	oj dl https://atcoder.jp/contests/abc${num}/tasks/abc${num}_b -d abc${num}/b/test
	cp boilerplate/* abc${num}/b
	sed -i -e 's/NUM/${num}/g' abc${num}/b/Makefile
	sed -i -e 's/ID/b/g' abc${num}/b/Makefile
	rm abc${num}/b/Makefile-e
	dotnet new console -o abc${num}/c
	oj dl https://atcoder.jp/contests/abc${num}/tasks/abc${num}_c -d abc${num}/c/test
	cp boilerplate/* abc${num}/c
	sed -i -e 's/NUM/${num}/g' abc${num}/c/Makefile
	sed -i -e 's/ID/c/g' abc${num}/c/Makefile
	rm abc${num}/c/Makefile-e
	dotnet new console -o abc${num}/d
	oj dl https://atcoder.jp/contests/abc${num}/tasks/abc${num}_d -d abc${num}/d/test
	cp boilerplate/* abc${num}/d
	sed -i -e 's/NUM/${num}/g' abc${num}/d/Makefile
	sed -i -e 's/ID/d/g' abc${num}/d/Makefile
	rm abc${num}/d/Makefile-e

.PHONY: login abc
