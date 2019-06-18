use std::io::stdin;
use std::process::exit;

#[allow(dead_code)]
fn input_strs() -> Vec<char> {
    let mut st = String::new();
    match stdin().read_line(&mut st) {
        Ok(_) => st.chars().collect(),
        Err(_) => panic!("err"),
    }
}

#[allow(dead_code)]
fn input_ints() -> Vec<u64> {
    let mut st = String::new();
    match stdin().read_line(&mut st) {
        Ok(_) => st.split_whitespace().map(|s| s.parse().unwrap()).collect(),
        Err(_) => panic!("err"),
    }
}

fn solve() {
    let l = input_ints();
    let n = l[0] as u32;
    if n % 2 == 0 {
        println!("{}", (2 as u32).pow(n / 2));
    } else {
        println!("{}", 0);
    }
}

fn main() {
    solve();
    exit(0);
}