# DevFlow CLI

CLI interface to manage your development flow in console

## Installation

```
git clone ..
```

## Using

### devflow

Main entry point is `devflow` command. Must be used to access all
tool commands.

Using:

```
$ devflow COMMAND ARGS
```

#### context

Manage **context**. Context concept represents workspace and settings
you are using when work with **devflow**. 

For example, you can use **work** context to manage tasks when do smth
relevant with your main job and **freelance** context to manage task
outside of work scedule.

- **i[nfo]** [default] print current context information
- **l[ist]** prints list of available contexts
- **a[dd]** creates and setup new context
- **c[hange]** changes specified context
