package main

import (
	"fmt"
	"os"
)

// RunCmd CLI arguments and executes commands
func RunCmd(config *Config) {
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
		fmt.Println("Usage:", execName, "COMMAND")
		return
	}

	switch os.Args[1] {
	case "context":
		contextCmd()
	case "board":
		fmt.Println("board command")
	case "h", "help":
		helpCmd()
	default:
		fmt.Println("Wrong command. Allowed commands are:")
		fmt.Println("\t[context,board,help]")
	}
}

func helpCmd() {
	// TODO: Add docs here
	fmt.Println("TODO: Help docs")
}

func contextCmd() {
	if len(os.Args) < 3 {
		fmt.Println("Usage:", "gl-cli", "context", "COMMAND")
		return
	}

	switch os.Args[2] {
	case "l", "list":
		contextListCmd()
	case "a", "add":
		fmt.Println("context add command")
	case "r", "remove":
		fmt.Println("context remove command")
	case "c", "change":
		fmt.Println("context change command")
	case "s", "select":
		fmt.Println("context select command")
	case "i", "info", "":
		fmt.Println("context info command")
	default:
		// TODO: Add detailed help docs here
		fmt.Println("Wrong command. Allowed commands are: TODO: [list,add,remove]")
	}
}

type context struct {
	UID   string
	Name  string
	Type  ContextType
	Token string
	URL   string
}

func contextListCmd() {
	fmt.Println("context list command")
	var ctxs = []string{"work", "freelance", "pet"}
	for _, v := range ctxs {
		fmt.Println(v)
	}
}

// ContextType enumeration
type ContextType int

const (
	// Undefined or wrong context type
	Undefined ContextType = 0
	// Local context - handles all data localy
	Local ContextType = 1
	// GitLab context - use GitLab API as tasks source
	GitLab ContextType = 2
)

func (d ContextType) String() string {
	return [...]string{"Undefined", "Local", "GitLab"}[d]
}
