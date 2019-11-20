package main

const execName = "devflow"

func main() {
	var c Config = Init()

	RunCmd(&c)
}
