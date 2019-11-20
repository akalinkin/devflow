package main

import (
	"github.com/akalinkin/devflow/cmd/devflow/commands"
	"github.com/akalinkin/devflow/cmd/devflow/config"
)

func main() {
	var c config.Config = config.Init()

	commands.RunCmd(&c)
}
