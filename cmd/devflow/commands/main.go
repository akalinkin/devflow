package commands

import (
	"fmt"
	"os"

	"github.com/akalinkin/devflow/cmd/devflow/config"
)

// RunCmd CLI arguments and executes commands
func RunCmd(c *config.Config) {
	// TODO: Check account if not -> suggest to login or setup TOKEN
	// TODO: Read CLI args and run relative command
	// TODO: Create commands:
	// 	- select board
	//  - output board
	//  - list WIP tasks
	//  - list TODO tasks
	//  - move task from TODO to WIP
	//  - move task from WIP to REVIEW
	//  - set estimate to task
	//  - set spend to task
	//  - add comment to task

	if len(os.Args) < 2 {
		fmt.Println("Usage: ", config.AppName, "[COMMAND]")
		return
	}

	switch os.Args[1] {
	case "c", "context":
		ContextCmd()
	case "b", "board":
		fmt.Println("board command")
	case "h", "help":
		HelpCmd()
	default:
		fmt.Println("Wrong command. Allowed commands are:")
		fmt.Println("\t[context,board,help]")
	}
}
